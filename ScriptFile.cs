using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    public class ScriptFile
    {
        public string filepath { get; set; } = string.Empty;
        public string filename { get; set; } = string.Empty;
        public Dictionary<string, string> param { get; set; } = null;
        public ScriptFile() {}
        public ScriptFile(string filepath,string filename, Dictionary<string, string> param) 
        { 
            this.filepath = filepath;
            this.filename = filename;
            this.param = param;
        }
    }
}
