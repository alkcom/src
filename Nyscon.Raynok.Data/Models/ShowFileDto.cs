using System;
using Newtonsoft.Json;

namespace Nyscon.Raynok.Data.Models
{
    public class ShowFileDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string FileName => $"{Id:N}-{Name}_{Revision}.{JsonDataRepository.ShowFileExtension}";

        [JsonIgnore]
        public int Revision { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime ModifiedAt { get; set; }
    }
}
