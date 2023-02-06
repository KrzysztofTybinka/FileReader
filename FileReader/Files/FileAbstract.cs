using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Files
{
    public abstract class FileAbstract
    {
        public string FileName { get; set; }
        public string Content { get; set; }

        public abstract string Serialize();
        public abstract void Deserialize(string content);
    }
}
