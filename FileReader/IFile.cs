using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public interface IFile
    {
        public List<object> ObjectsToList(string root);
        //public void Parse(string content);
    }
}
