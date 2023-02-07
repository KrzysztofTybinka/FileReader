using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace FileReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dialogues.Start();

            while (true)
            {
                Dialogues.Menu();
            }

        }
    }
}