using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader.Files
{
    /// <summary>
    /// Initilizes a new instance of the XMLFile class.
    /// Represents a XML file.
    /// </summary>
    public class XMLFile : FileAbstract
    {

        public XMLFile()
        {

        }

        /// <summary>
        /// Creates xml file from given dictionary.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rootValue"></param>
        /// <returns>XDocument</returns>
        public XDocument CreateXmlFile(Dictionary<string, string> data, string rootValue)
        {
            XDocument xmlFile = new XDocument();
            XElement root = new XElement(rootValue);

            foreach (var item in data)
            {
                XElement element = new XElement(item.Key, item.Value);
                root.Add(element);
            }

            xmlFile.Add(root);
            return xmlFile;
        }

        public override void Deserialize(string content)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Separates xml objects by given elemen
        /// and parses it to list of objects.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>List of XML elements.</returns>
        public List<object> ObjectsToList(string root)
        {
            List<object> list = new List<object>();
            XElement? rootElement = file.Element(root);

            if (rootElement != null)
            {
                foreach (var element in rootElement.Elements())
                {
                    list.Add(element);
                }
            }
            return list;
        }

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
            return file.ToString();
        }
    }
}
