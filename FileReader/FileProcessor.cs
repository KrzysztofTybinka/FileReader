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

        private FileAbstract GetFile(string type, string content)
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

        private string GetFileType(string url)
        {
            try
            {
                FileInfo fi = new FileInfo(url);
                return fi.Extension;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command.");
            }
        }
    }
}
