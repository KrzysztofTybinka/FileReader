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

        public bool DownloadFile(string source)
        {
            try
            {
                if (IsValidUrl(source))
                {
                    using (var webClient = new WebClient())
                    {
                        file = (JObject)webClient.DownloadString(source);
                        return true;
                    }
                }
                if (IsValidPath(source))
                {

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

        private bool IsValidPath(string path)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                return fi.Extension == ".json";
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
