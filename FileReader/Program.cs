using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace FileReader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://fortedigital.github.io/Back-End-Internship-Task/interns.json";

            HttpClient client = new HttpClient();

            string jsonString = await client.GetStringAsync(url);


            JObject jsonObj = JObject.Parse(jsonString);


            Console.WriteLine(jsonObj);
        }
    }
}