using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms
{
    class Config
    {
        public string ApiKey { get; set; } = "";
    }

    // Response myDeserializedClass = JsonConvert.DeserializeObject<Response>myJsonResponse);
    public class Data
    {
        public string author { get; set; }
        public string contributor { get; set; }
        public string language { get; set; }
        public int length { get; set; }
        public int max_skill { get; set; }
        public int min_skill { get; set; }
        public string text { get; set; }
        public int tid { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }

    public class TextResponse
    {
        public Data data { get; set; }
        public object error { get; set; }
        public bool success { get; set; }
    }



}
