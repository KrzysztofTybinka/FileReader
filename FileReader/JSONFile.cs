using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader
{
    /// <summary>
    /// Initilizes a new instance of the JSONFile class.
    /// Represents a JSON file.
    /// </summary>
    public class JSONFile
    {
        private JObject file = new JObject();


        public JSONFile(string url)
        {
            file = DownloadFileAsync(url).Result;
        }

        public List<object> GetAttributeValues(string propertyName)
        {
            string[] properties = propertyName.Split('.');
            List<object> list = new List<object>();

            foreach (KeyValuePair<string, JToken?> prop in file)
            {

            }
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
