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
        private JObject file;


        public JSONFile(string url)
        {
            file = new JObject();
            file = DownloadFileAsync(url).Result;
        }

        public override string ToString()
        {
            return file.ToString();
        }

        /// <summary>
        /// Separates json objects by given attribute
        /// and parses it to list of objects.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>List of JSON elements.</returns>
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

        /// <summary>
        /// Downloads JSON content as JObject from given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>JObject with downloaded json content.</returns>
        /// <exception cref="FileLoadException"></exception>
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

        /// <summary>
        /// Checks if file type from given url is of type JSON.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>True if file is JSON, otherwise false.</returns>
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
