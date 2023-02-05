using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace FileReader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://fortedigital.github.io/Back-End-Internship-Task/interns.csv";

            CSVFile f = new CSVFile(url);
            f.ObjectsToList("interns");
            Console.Write(f.ToString());
        }
    }
}