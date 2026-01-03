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
        public int BestWpm { get; set; }
        public int AvgWpm { get; set; }
        public float AvgAcc { get; set; }
        public int CompletedRuns { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
