using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader
{
    public class CSVFile : IFile
    {
        private string file;

        public CSVFile(string url)
        {
            file = DownloadFileAsync(url).Result;
        }


        private async Task<string> DownloadFileAsync(string url)
        {
            try
            {
                if (IsValidUrl(url))
                {
                    HttpClient client = new HttpClient();
                    string csvString = await client.GetStringAsync(url);
                    return csvString;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                throw new FileLoadException("File not loaded.");
            }
        }
        public List<object> ObjectsToList(string root)
        {
            try
            {
                List<object> list = new List<object>();

                var values = file.Split('\n');

                for (int i = 1; i < values.Length - 1; i++)
                {
                    list.Add(values[i].Split(',').ToList());
                }
                return list;
            }
            catch (Exception)
            {
                throw new FileNotFoundException("Cannot get file.");
            }
        }

        private bool IsValidUrl(string url)
        {
            try
            {
                FileInfo fi = new FileInfo(url);
                return fi.Extension == ".csv";
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
