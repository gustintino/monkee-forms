using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Grid_data
{
    public class LeaderboardRow
    {
        public int Rank { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Wpm { get; set; }
        public float Accuracy { get; set; }
    }
}
