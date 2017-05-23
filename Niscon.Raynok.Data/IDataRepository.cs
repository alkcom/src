using System;
using System.Collections.Generic;
using Niscon.Raynok.Data.Models;

namespace Niscon.Raynok.Data
{
    public interface IDataRepository
    {
        ShowDto GetShow(string name);
        List<ShowFileDto> GetShowFiles();
        ShowDto SaveShow(ShowDto currentShow, string newName = null, bool checkFileExists = false);
        List<AxisDto> GetAxes();
        List<CueDto> GetDefaultCues();
        bool DeleteShow(ShowFileDto show);
    }
}