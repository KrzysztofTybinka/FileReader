using FileReader.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = FileReader.Files.File;

namespace FileReader
{
    public class FileProcessor
    {

        public File DeserializeFile(string content, string name, string type)
        {
            File? file = null;

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
            file.Deserialize(name, content);
            return file;
        }

        public string SerializeFile(File file)
        {
            return file.Serialize();
        }


    }
}
