using FileReader.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileProcessor
    {

        public FileAbstract DeserializeFile(string content, string type)
        {
            FileAbstract file = null;

            switch (type)
            {
                case ".json":
                    file = new JSONFile();
                    break;

                case ".xml":
                    file = new XMLFile();
                    break;

                case ".csv":
                    file = new CSVFile();
                    break;

                default:
                    throw new InvalidOperationException("File does not exist");
            }
            file.Deserialize(content);
            return file;
        }

        public string SerializeFile(FileAbstract file)
        {
            return file.Serialize();
        }


    }
}
