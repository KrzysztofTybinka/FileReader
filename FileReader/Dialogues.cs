﻿using Microsoft.EntityFrameworkCore.Metadata;
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
            Console.WriteLine("Choose one option:\n0. Exit\n1. Download file\n2. Open file" +
                "\n3. Create file\n4. Show files\nEnter a number...");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "0":
                        Environment.Exit(0);
                        break;

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

                    case "5":
                        break;

                    case "6":
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
                string name;
                string type = GetFileType(url);
                string content;

                if(type == ".zip")
                {
                    Unzipper unzip = new Unzipper(url);
                    content = unzip.UnzipTypeOut(out type);
                }
                else
                {
                    content = DownloadFileAsync(url).Result;
                }

                do
                {
                    Console.Write("Enter file name: ");
                    name = Console.ReadLine() ?? throw new ArgumentNullException();
                } while (FileExists(name + type));

                IFile file = GetFile(type, content);

                using (var context = new FileContext())
                {
                    var f = new File(name + type, file.ToString()!);

                    context.Files.Add(f);
                    context.SaveChanges();
                }
                Console.WriteLine("File saved successfully.\n");
                Menu();
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't download the file. Please try again...");
                Menu();
            }

        }

        private static void OpenFile()
        {
            Console.WriteLine("You chose to open a file.");
            Console.Write("Enter file name: ");
            string name = Console.ReadLine() ?? throw new ArgumentNullException();

            if (FileExists(name))
            {
                using (var context = new FileContext())
                {

                }
            }
        }

        private static void CreateFile()
        {

        }

        private static void ShowFiles()
        {

        }

        private static bool FileExists(string name)
        {
            using (var context = new FileContext())
            {
                bool exists = context.Files.Any(f => f.Name == name);
                if (exists)
                {
                    Console.WriteLine("File with this name already exists.");
                    return true;
                }
            }
            return false;
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

        private static IFile GetFile(string type, string content)
        {
            switch (type)
            {
                case ".json":
                    return new JSONFile(content);

                case ".xml":
                    return new XMLFile(content);

                case ".csv":
                    return new CSVFile(content);

                default:
                    throw new InvalidOperationException("File does not exist");
            }
        }

        private static async Task<string> DownloadFileAsync(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(url);
                return content;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid operation.");
            }
        }
    }
}
