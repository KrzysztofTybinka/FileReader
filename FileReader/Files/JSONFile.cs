using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader.Files
{
    /// <summary>
    /// Initilizes a new instance of the JSONFile class.
    /// Represents a JSON file.
    /// </summary>
    public class JSONFile : FileAbstract
    {

        public JSONFile()
        {

        }

        public override void Deserialize(string content)
        {
            throw new NotImplementedException();
        }

        public override string Serialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Separates json objects by given attribute
        /// and parses it to list of objects.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>List of JSON elements.</returns>
        public List<object> ObjectsToList(string root)
        {
            List<object> list = new List<object>();
            JToken? rootElement = file[root];

            if (rootElement != null)
            {
                foreach (var item in rootElement)
                {
                    list.Add(item);
                }
            }
            return list;
        }



        /// <summary>
        /// Returns representation of this JSON file.
        /// </summary>
        /// <returns>The representation of this JSON file.</returns>
        public override string ToString()
        {
            return file.ToString();
        }
    }
}
