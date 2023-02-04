using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    /// <summary>
    /// Initilizes a new instance of the JSONFile class.
    /// Represents a JSON file.
    /// </summary>
    public class JSONFile
    {
        private JObject file = new JObject();


        public JSONFile()
        {

        }

        public List<string> GetAttributeValues(string attributeName)
        {
            return GetAttributeValues(file, attributeName);
        }

        private List<string> GetAttributeValues(JObject json, string attributeName)
        {
            var attributeValues = new List<string>();

            foreach (var property in json.Properties())
            {
                var propertyValue = property.Value;

                if (propertyValue.Type == JTokenType.Object)
                {
                    attributeValues.AddRange(GetAttributeValues((JObject)propertyValue, attributeName));
                }
                else if (property.Name == attributeName)
                {
                    attributeValues.Add(propertyValue.ToString());
                }
            }

            return attributeValues;
        }

        public async Task<bool> DownloadFileAsync(string url)
        {
            try
            {
                if (IsValidUrl(url))
                {
                    HttpClient client = new HttpClient();
                    string jsonString = await client.GetStringAsync(url);
                    file = JObject.Parse(jsonString);
                    return true;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                return false;
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
