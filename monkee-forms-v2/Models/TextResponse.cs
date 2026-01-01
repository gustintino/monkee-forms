using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Models
{
    // all of the names must be lower case in order to corectly parse it with jsonserializer

    // Response myDeserializedClass = JsonConvert.DeserializeObject<Response>myJsonResponse);
    public class TextResponse
    {
        public TextData data { get; set; }
        public object error { get; set; }
        public bool success { get; set; }
    }

    // helper class
    public class TextData
    {
        public string author { get; set; }
        public string contributor { get; set; }
        public string language { get; set; }
        public int length { get; set; }
        public int Max_skill { get; set; }
        public int Min_skill { get; set; }
        public string text { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }


}
