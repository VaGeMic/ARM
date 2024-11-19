using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    internal class ScriptFile
    {
        string filepath {  get; set; }
        string filename { get; set; }
        Dictionary<string, string> param { get; set; }
        public ScriptFile(string filepath,string filename, Dictionary<string, string> param) 
        { 
            this.filepath = filepath;
            this.filename = filename;
            this.param = param;
        }
    }
}
