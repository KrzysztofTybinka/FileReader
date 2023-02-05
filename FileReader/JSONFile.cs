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

namespace FileReader
{
    /// <summary>
    /// Initilizes a new instance of the JSONFile class.
    /// Represents a JSON file.
    /// </summary>
    public class JSONFile : IFile
    {
        private JObject file = new JObject();


        public JSONFile(string url)
        {
            file = DownloadFileAsync(url).Result;
        }

        public List<object> ObjectsToList(string root)
        {
            List<object> list = new List<object>();
            JToken? rootElement = file[root];

            if(rootElement != null)
            {
                foreach (var item in rootElement)
                {
                    list.Add(item);
                }
            }
            return list;
        }       


        private async Task<JObject> DownloadFileAsync(string url)
        {
            try
            {
                if (IsValidUrl(url))
                {
                    HttpClient client = new HttpClient();
                    string jsonString = await client.GetStringAsync(url);
                    return JObject.Parse(jsonString);
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
                return fi.Extension == ".json";
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
