using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FileReader.Files
{
    /// <summary>
    /// Initilizes a new instance of the XMLFile class.
    /// Represents a XML file.
    /// </summary>
    public class XMLFile : File
    {

        public XMLFile()
        {
            Type = ".xml";
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
            XmlSerializer serializer = new XmlSerializer(typeof(XElement));
            XElement xml;

            using (var stringReader = new StringReader(Content!))
            {
                xml = (XElement)serializer.Deserialize(stringReader)!;
            }

            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                serializer.Serialize(stringWriter, xml);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Creates XMLFile from given dictionary.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rootValue"></param>
        /// <returns>File.</returns>
        public override File CreateFile(string name, Dictionary<string, List<string>> data)
        {
            FileName = name;
            XDocument xmlFile = new XDocument();
            XElement root = new XElement("Root");

            foreach (var item in data)
            {
                XElement element = new XElement(item.Key, item.Value);
                root.Add(element);
            }

            xmlFile.Add(root);
            Content = xmlFile.ToString();
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
