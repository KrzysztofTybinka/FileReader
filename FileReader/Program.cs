using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace FileReader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Dialogues.Start();

            while (true)
            {
                Dialogues.Menu();
            }

        }
    }
}