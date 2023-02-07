using Newtonsoft.Json;
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
    public class JSONFile : File
    {

        public JSONFile()
        {
            Type = ".json";
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
            dynamic json = JsonConvert.DeserializeObject(Content!)!;
            return JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        /// <summary>
        /// Creates JSONFile from given dictionary.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rootValue"></param>
        /// <returns>File.</returns>
        public override File CreateFile(string name, Dictionary<string, List<string>> data)
        {
            FileName = name;
            Content =  JsonConvert.SerializeObject(data, Formatting.Indented);
            return this;
        }


        /// <summary>
        /// Returns representation of this JSON file.
        /// </summary>
        /// <returns>The representation of this JSON file.</returns>
        public override string ToString()
        {
            return Content;
        }
    }
}
