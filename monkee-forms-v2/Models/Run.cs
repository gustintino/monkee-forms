using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Models
{
    public class Run
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime CompletedAt { get; set; }
        public int TextID { get; set; }
        public float Wpm { get; set; }
        public float Accuracy { get; set; }
    }
}
