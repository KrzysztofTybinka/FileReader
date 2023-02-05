using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader
{
    public class XMLFile
    {
        private XDocument file = new XDocument();
        public XMLFile(string url)
        {
            file = DownloadFileAsync(url).Result;
        }

        private async Task<XDocument> DownloadFileAsync(string url)
        {
            HttpClient client = new HttpClient();
            string xmlString = await client.GetStringAsync(url);
            return XDocument.Parse(xmlString);
        }
    }
}
