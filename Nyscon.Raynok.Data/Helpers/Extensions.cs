using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyscon.Raynok.Data.Models;

namespace Nyscon.Raynok.Data.Helpers
{
    public static class Extensions
    {
        public static string GetFileName(this ShowFileDto showFile)
        {
            return $"{showFile.Id:N}-{showFile.Name}_{showFile.Revision}.{JsonDataRepository.ShowFileExtension}";
        }
    }
}
