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
        /// Creates xml file from given dictionary.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rootValue"></param>
        /// <returns>XDocument</returns>
        public override File CreateFile(string name, Dictionary<string, string> data)
        {
            XDocument xmlFile = new XDocument();
            XElement root = new XElement("Root");

            foreach (var item in data)
            {
                XElement element = new XElement(item.Key, item.Value);
                root.Add(element);
            }

            xmlFile.Add(root);
            FileName = name;
            Content = xmlFile.ToString();
            return this;
        }

        public override void Deserialize(string name, string content)
        {
            FileName = name;
            Content = content;
        }

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
        /// Separates xml objects by given elemen
        /// and parses it to list of objects.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>List of XML elements.</returns>
        //public List<object> ObjectsToList(string root)
        //{
        //    List<object> list = new List<object>();
        //    XElement? rootElement = file.Element(root);

        //    if (rootElement != null)
        //    {
        //        foreach (var element in rootElement.Elements())
        //        {
        //            list.Add(element);
        //        }
        //    }
        //    return list;
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
