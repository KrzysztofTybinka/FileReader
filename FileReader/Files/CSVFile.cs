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
    public class CSVFile : FileAbstract
    {

        public CSVFile()
        {

        }

        public override void Deserialize(string content)
        {
            throw new NotImplementedException();
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

        public override string Serialize()
        {
            throw new NotImplementedException();
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
