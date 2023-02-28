using System.Collections.Generic;
using System.Linq;

namespace StepsStatistic.Models
{
    public class UserModel
    {
        public string User { get; set; }
        public List<StatModel> Stats { get; set; }
        public double AvgSteps => Stats.Average(x => x.Steps);
        public int BestResult => Stats.Max(x => x.Steps);
        public int WorstResult => Stats.Min(x => x.Steps);
    }
}