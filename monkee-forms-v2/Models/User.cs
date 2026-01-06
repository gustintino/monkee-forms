using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public float BestWpm { get; set; }
        public float AvgWpm_Last10Runs { get; set; }
        public float AvgAcc_Last10Runs { get; set; }
        public int CompletedRuns { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
