using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    /// <summary>
    /// Provides methods containg user dialogues.
    /// </summary>
    public static class Dialogues
    {
        /// <summary>
        /// Starting method writing basic
        /// application information.
        /// </summary>
        public static void Start()
        {
            Console.WriteLine("File Reader is a command-line interface application that provides \n" +
                "methods to create files in different formats, download files from \n" +
                "given url, unzip, deserialize and/or read them. \n");
            Console.WriteLine("Accessible file types: XML, JSON, CSV, (aslo in ZIP format).");
            Console.WriteLine("─────────────────────────────────────────────────────────────────\n");
        }

        /// <summary>
        /// Writes menu information and allows to 
        /// choose one of the menu options.
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine("Choose one option:\n1. Download file\n2. Open file" +
                "\n3. Create file\n4. Show files\nEnter a number...");

            int option;
            while ((!int.TryParse(Console.ReadLine(), out option)) && (option >= 1 & option <=4))
            {
                Console.WriteLine("Option not supported. Try again...");
            }

            Console.WriteLine(option);
        }

        private static void DownloadFile()
        {

        }
    }
}
