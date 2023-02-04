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

        public async Task<bool> DownloadFile(string url)
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
