using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader
{
    /// <summary>
    /// Initilizes a new instance of the CSVFile class.
    /// Represents a CSV file.
    /// </summary>
    public class CSVFile : IFile
    {
        private string file;

        public CSVFile(string url)
        {
            file = DownloadFileAsync(url).Result;
        }

        /// <summary>
        /// Deserializes CSV string representation
        /// and parses it to list of objects.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>List of objects.</returns>
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

        /// <summary>
        /// Downloads CSV content as string from given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>String with downloaded csv content.</returns>
        /// <exception cref="FileLoadException"></exception>
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

        /// <summary>
        /// Checks if file type from given url is of type CSV.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>True if file is CSV type, otherwise false.</returns>
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
