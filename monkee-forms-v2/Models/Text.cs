using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Models
{
    public class Text
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Length { get; set; }
        public string TextContent { get; set; } = string.Empty;
    }
}
