using FileReader.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = FileReader.Files.File;

namespace FileReader
{
    /// <summary>
    /// Provides methods for file serialization and creation.
    /// </summary>
    public class FileProcessor
    {
        /// <summary>
        /// Determies what type of file to create and creates it.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <returns>File object.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public File CreateFile(string name, string type, Dictionary<string, List<string>> content)
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
                    throw new InvalidOperationException("Invalid file type");
            }
            file.CreateFile(name, content);
            return file;
        }

        /// <summary>
        /// Creates a new instance of a file object, either a JSONFile,
        /// XMLFile, or CSVFile, depending on the value of type.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns>File object.</returns>
        /// <exception cref="InvalidOperationException"></exception>
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

        /// <summary>
        /// Takes a "File" object as input and returns the
        /// serialized string representation of the file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>String representation of the file.</returns>
        public string SerializeFile(File file)
        {
            return file.Serialize();
        }


    }
}
