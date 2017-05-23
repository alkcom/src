using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Niscon.Raynok.Data;
using Niscon.Raynok.Data.Models;
using Niscon.Raynok.Extensions;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Services
{
    public class ShowsService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;

        public ShowsService(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        public List<Axis> GetAxes()
        {
            List<AxisDto> axesDto = _dataRepository.GetAxes();

            return _mapper.Map<List<Axis>>(axesDto).OrderBy(a => a.OrderNumber).ToList();
        }

        public List<Cue> GetDefaultCues()
        {
            List<CueDto> cuesDto = _dataRepository.GetDefaultCues();

            return _mapper.Map<List<Cue>>(cuesDto);
        }

        public List<ShowFile> GetShowFiles()
        {
            List<ShowFileDto> showFilesDto = _dataRepository.GetShowFiles();

            return _mapper.Map<List<ShowFile>>(showFilesDto);
        }

        public Show GetShow(string name)
        {
            ShowDto showDto = _dataRepository.GetShow(name);

            //TODO: implement axis-profile mapping inside automapper
            return _mapper.Map<Show>(showDto);
        }

        public Show IncreaseShowRevision(Show currentShow)
        {
            return SaveShowInternal(currentShow, currentShow.Name.UpdateRevision(currentShow.Revision+1));
        }

        public Show SaveShow(Show currentShow)
        {
            return SaveShowInternal(currentShow);
        }

        public Show SaveShowAs(Show currentShow, string newName)
        {
            return SaveShowInternal(currentShow, newName);
        }

        public bool DeleteShow(ShowFile showFile)
        {
            return _dataRepository.DeleteShow(_mapper.Map<ShowFileDto>(showFile));
        }

        private Show SaveShowInternal(Show currentShow, string newShowName = null)
        {
            ShowDto showDto = _mapper.Map<ShowDto>(currentShow);

            ShowDto resultingShowDto = _dataRepository.SaveShow(showDto, newShowName);

            //TODO: implement axis-profile mapping inside automapper
            return _mapper.Map<Show>(resultingShowDto);
        }
    }
}
