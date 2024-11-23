using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    internal class ScriptFile
    {
        public string filepath {  get; set; }
        public string filename { get; set; }
        public Dictionary<string, string> param { get; set; }
        public ScriptFile(string filepath,string filename, Dictionary<string, string> param) 
        { 
            this.filepath = filepath;
            this.filename = filename;
            this.param = param;
        }
    }
}
