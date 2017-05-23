using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Niscon.Raynok.Data.Models;
using Niscon.Raynok.Shared.Exceptions;

namespace Niscon.Raynok.Data
{
    public class JsonDataRepository : IDataRepository
    {
        public const string ShowFileExtension = "show";
        public const string AxesFileName = "axes.json";
        public const string DefaultCuesFileName = "default-cues.json";

        private readonly JsonSerializer _jsonSerializer;
        private readonly DirectoryInfo _directoryInfo;

        public JsonDataRepository(string basePath, JsonSerializerSettings jsonSerializerSettings = null)
        {
            if (jsonSerializerSettings == null)
            {
                jsonSerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    Formatting = Formatting.Indented
                };
            }

            _jsonSerializer = JsonSerializer.Create(jsonSerializerSettings);

            _directoryInfo = new DirectoryInfo(basePath);
        }

        public List<ShowFileDto> GetShowFiles()
        {
            FileInfo[] files = _directoryInfo.GetFiles($"*.{ShowFileExtension}");

            Dictionary<Guid, ShowFileDto> showFiles = new Dictionary<Guid, ShowFileDto>();

            return files.Select(ShowFileFromFileInfo).ToList();
        }

        public ShowDto GetShow(string name)
        {
            ShowFileDto newestFile = _directoryInfo.GetFiles($"{name}.{ShowFileExtension}")
                .Select(ShowFileFromFileInfo)
                .FirstOrDefault();

            if (newestFile == null)
            {
                return null;
            }

            using (StreamReader sr = new StreamReader(Path.Combine(_directoryInfo.FullName, newestFile.FileName)))
            using (JsonTextReader jr = new JsonTextReader(sr))
            {
                ShowDto showDto = _jsonSerializer.Deserialize<ShowDto>(jr);
                showDto.Name = newestFile.Name;
                showDto.CreatedAt = newestFile.CreatedAt;
                showDto.ModifiedAt = newestFile.ModifiedAt;

                return showDto;
            }
        }

        public ShowDto SaveShow(ShowDto currentShow, string newName = null, bool checkFileExists = false)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                currentShow.Name = newName;
            }

            if (checkFileExists)
            {
                if (_directoryInfo.GetFiles(currentShow.FileName).Any())
                {
                    throw new FileExistsException(currentShow.FileName);
                }
            }

            using (StreamWriter sw = new StreamWriter(Path.Combine(_directoryInfo.FullName, currentShow.FileName), false))
            using (JsonTextWriter jw = new JsonTextWriter(sw))
            {
                _jsonSerializer.Serialize(jw, currentShow);

                jw.Flush();
                sw.Flush();

                return currentShow;
            }
        }

        private ShowFileDto ShowFileFromFileInfo(FileInfo file)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);

            return new ShowFileDto
            {
                Name = name,
                CreatedAt = file.CreationTime,
                ModifiedAt = file.LastWriteTime
            };
        }

        public List<AxisDto> GetAxes()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(_directoryInfo.FullName, AxesFileName)))
            using (JsonTextReader jr = new JsonTextReader(sr))
            {
                List<AxisDto> axesDto = _jsonSerializer.Deserialize<List<AxisDto>>(jr);

                return axesDto;
            }
        }

        public List<CueDto> GetDefaultCues()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(_directoryInfo.FullName, DefaultCuesFileName)))
            using (JsonTextReader jr = new JsonTextReader(sr))
            {
                List<CueDto> cuesDto = _jsonSerializer.Deserialize<List<CueDto>>(jr);

                return cuesDto;
            }
        }

        public bool DeleteShow(ShowFileDto show)
        {
            FileInfo file = new FileInfo(Path.Combine(_directoryInfo.FullName, show.FileName));

            if (!file.Exists)
            {
                return false;
            }

            file.Delete();
            return true;
        }
    }
}
