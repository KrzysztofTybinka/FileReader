using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        DownloadFile();
                        break;

                        case "2":
                        OpenFile();
                        break;

                    case "3":
                        CreateFile();
                        break;

                    case "4":
                        ShowFiles();
                        break;

                    default:
                        Console.WriteLine("Option not supported. Try again...");
                        continue;
                }

            }
        }

        private static void DownloadFile()
        {
            try
            {
                Console.WriteLine("You chose to download a file");
                Console.Write("Enter url: ");
                string url = Console.ReadLine() ?? throw new ArgumentNullException();
                Console.Write("Enter file name: ");
                string name = Console.ReadLine() ?? throw new ArgumentNullException();
                string type = GetFileType(url);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid operation.");
            }

        }

        private static void OpenFile()
        {

        }

        private static void CreateFile()
        {

        }

        private static void ShowFiles()
        {

        }

        private static string GetFileType(string url)
        {
            try
            {
                FileInfo fi = new FileInfo(url);
                return fi.Extension;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command.");
            }
        }
    }
}
