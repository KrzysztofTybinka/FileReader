using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader
{
    public class XMLFile : IFile
    {
        private XDocument file = new XDocument();
        public XMLFile(string url)
        {
            file = DownloadFileAsync(url).Result;
        }

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
    }
}
