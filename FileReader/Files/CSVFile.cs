using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader.Files
{
    /// <summary>
    /// Initilizes a new instance of the CSVFile class.
    /// Represents a CSV file.
    /// </summary>
    public class CSVFile : File
    {

        public CSVFile()
        {
            Type = ".csv";
        }

        /// <summary>
        /// Deserializes string to this object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public override void Deserialize(string name, string content)
        {
            FileName = name;
            Content = content;
        }

        /// <summary>
        /// Serializes this object to a string.
        /// </summary>
        /// <returns>String representation of serialized object.</returns>
        public override string Serialize()
        {
            return Content;
        }

        /// <summary>
        /// Creates CSVFile from given dictionary.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rootValue"></param>
        /// <returns>File.</returns>
        public override File CreateFile(string name, Dictionary<string, List<string>> data)
        {
            FileName = name;
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.Append(item.Key);
                sb.Append(",");
                sb.Append(string.Join(",", item.Value));
                sb.AppendLine();
            }
            Content = sb.ToString();
            return this;
        }

        /// <summary>
        /// Returns representation of this XML file.
        /// </summary>
        /// <returns>The representation of this XML file.</returns>
        public override string ToString()
        {
            return Content;
        }
    }
}
