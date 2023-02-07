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

        public override void Deserialize(string name, string content)
        {
            FileName = name;
            Content = content;
        }

        public override string Serialize()
        {
            return Content;
        }

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
        /// Deserializes CSV string representation
        /// and parses it to list of objects.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>List of objects.</returns>
        //public List<object> ObjectsToList(string root)
        //{
        //    try
        //    {
        //        List<object> list = new List<object>();

        //        var values = file.Split('\n');

        //        for (int i = 1; i < values.Length - 1; i++)
        //        {
        //            list.Add(values[i].Split(',').ToList());
        //        }
        //        return list;
        //    }
        //    catch (Exception)
        //    {
        //        throw new FileNotFoundException("Cannot get file.");
        //    }
        //}



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
