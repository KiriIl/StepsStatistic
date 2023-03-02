using Newtonsoft.Json;

namespace StepsStatistic.Models
{
    public class StatModel
    {
        public int Rank { get; set; }
        public string Status { get; set; }
        public int Steps { get; set; }
        [JsonIgnore]
        public string Article { get; set; }
    }
}