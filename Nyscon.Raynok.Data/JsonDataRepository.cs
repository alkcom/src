using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Niscon.Raynok.Shared.Exceptions;
using Nyscon.Raynok.Data.Helpers;
using Nyscon.Raynok.Data.Models;

namespace Nyscon.Raynok.Data
{
    public class JsonDataRepository : IDataRepository
    {
        public const string ShowFileExtension = "json";
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
            foreach (FileInfo file in files)
            {
                ShowFileDto showFile = ShowFileFromFileInfo(file);

                if (showFile == null)
                {
                    continue;
                }

                ShowFileDto existingShowFile;
                if (showFiles.TryGetValue(showFile.Id, out existingShowFile))
                {
                    if (showFile.Revision > existingShowFile.Revision)
                    {
                        showFiles[showFile.Id] = showFile;
                    }
                }
                else
                {
                    showFiles.Add(showFile.Id, showFile);
                }
            }

            return showFiles.Values.ToList();
        }

        public ShowDto GetShow(Guid id, int revision = int.MinValue)
        {
            ShowFileDto newestFile = _directoryInfo.GetFiles($"{id:N}*.{ShowFileExtension}")
                .Select(ShowFileFromFileInfo)
                .OrderByDescending(f => f.Revision)
                .FirstOrDefault();

            if (newestFile == null)
            {
                return null;
            }

            using (StreamReader sr = new StreamReader(Path.Combine(_directoryInfo.FullName, newestFile.FileName)))
            using (JsonTextReader jr = new JsonTextReader(sr))
            {
                ShowDto showDto = _jsonSerializer.Deserialize<ShowDto>(jr);
                showDto.Id = newestFile.Id;
                showDto.Name = newestFile.Name;
                showDto.Revision = newestFile.Revision;
                showDto.CreatedAt = newestFile.CreatedAt;
                showDto.ModifiedAt = newestFile.ModifiedAt;

                return showDto;
            }
        }

        public ShowDto SaveShow(ShowDto currentShow, ShowFileDto newName = null, bool checkFileExists = false)
        {
            if (newName != null)
            {
                if (newName.Id != default(Guid) && newName.Id != currentShow.Id)
                {
                    currentShow.Id = newName.Id;
                }

                if (!string.IsNullOrEmpty(newName.Name))
                {
                    currentShow.Name = newName.Name;
                }

                if (newName.Revision != default(int))
                {
                    currentShow.Revision = newName.Revision;
                }
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
            string[] parts = Path.GetFileNameWithoutExtension(file.Name).Split('-');

            if (parts.Length < 2)
            {
                return null;
            }

            string[] nameParts = parts[1].Split('_');

            return new ShowFileDto
            {
                Id = Guid.Parse(parts[0]),
                Name = nameParts[0],
                Revision = Int32.Parse(nameParts[1]),
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

        public bool DeleteShow(ShowFileDto show, bool withAllRevisions = false)
        {
            List<FileInfo> files = new List<FileInfo>();

            if (withAllRevisions)
            {
                files.AddRange(_directoryInfo.GetFiles($"{show.Id:N}*.{ShowFileExtension}"));
            }
            else
            {
                files.Add(new FileInfo(Path.Combine(_directoryInfo.FullName, show.GetFileName())));
            }

            if (!files.Any())
            {
                return false;
            }

            foreach (FileInfo file in files)
            {
                file.Delete();
            }

            return true;
        }
    }
}
