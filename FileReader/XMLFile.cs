using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader
{
    /// <summary>
    /// Initilizes a new instance of the XMLFile class.
    /// Represents a XML file.
    /// </summary>
    public class XMLFile : IFile
    {
        private XDocument file;
        public XMLFile(string url)
        {
            file = new XDocument();
            file = DownloadFileAsync(url).Result;
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

        /// <summary>
        /// Downloads XML content as XDocument from given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>XDocument with downloaded json content.</returns>
        /// <exception cref="FileLoadException"></exception>
        private async Task<XDocument> DownloadFileAsync(string url)
        {
            try
            {
                if (IsValidUrl(url))
                {
                    HttpClient client = new HttpClient();
                    string xmlString = await client.GetStringAsync(url);
                    return XDocument.Parse(xmlString);
                }
                throw new Exception();
            }
            catch (Exception)
            {
                throw new FileLoadException("File not loaded.");
            }
        }

        /// <summary>
        /// Checks if file type from given url is of type XML.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>True if file is XML, otherwise false.</returns>
        private bool IsValidUrl(string url)
        {
            try
            {
                FileInfo fi = new FileInfo(url);
                return fi.Extension == ".xml";
            }
            catch (Exception)
            {
                return false;
            }
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
