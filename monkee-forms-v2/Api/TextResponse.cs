using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Api.TypeRacerApi
{
    // all of the names must be lower case in order to corectly parse it with jsonserializer
    // even though intellisense does not like it

    // this is just to deserialize the typeracer api response

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
        public int max_skill { get; set; }
        public int min_skill { get; set; }
        public string text { get; set; }
        public int tid { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }


}
