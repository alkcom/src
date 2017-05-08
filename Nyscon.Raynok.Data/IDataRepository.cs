using System;
using System.Collections.Generic;
using Nyscon.Raynok.Data.Models;

namespace Nyscon.Raynok.Data
{
    public interface IDataRepository
    {
        ShowDto GetShow(Guid id, int revision = int.MinValue);
        List<ShowFileDto> GetShowFiles();
        ShowDto SaveShow(ShowDto currentShow, ShowFileDto newName = null, bool checkFileExists = false);
        List<AxisDto> GetAxes();
        List<CueDto> GetDefaultCues();
        bool DeleteShow(ShowFileDto show, bool withAllRevisions = false);
    }
}