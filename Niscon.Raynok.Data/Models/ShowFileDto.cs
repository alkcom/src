using System;
using Newtonsoft.Json;

namespace Niscon.Raynok.Data.Models
{
    public class ShowFileDto
    {

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string FileName => $"{Name}.{JsonDataRepository.ShowFileExtension}";

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime ModifiedAt { get; set; }
    }
}
