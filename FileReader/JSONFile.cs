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

        public bool CreateFromUrl(string url)
        {
            try
            {
                if (IsValidUrl(url))
                {
                    using (var webClient = new WebClient())
                    {
                        file = (JObject)webClient.DownloadString(url);
                        return true;
                    }
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
            FileInfo fi = new FileInfo(url);
            return fi.Extension == ".json";
        }

        private bool IsValidPath(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi.Extension == ".json";
        }


    }
}
