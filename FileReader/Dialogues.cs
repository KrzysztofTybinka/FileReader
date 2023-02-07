﻿using FileReader.Files;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Resources;
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
            Console.WriteLine("\nYou chose to download a file.\nEnter url: ");
            string url = Console.ReadLine() ?? throw new ArgumentNullException();
            Console.WriteLine("Enter file name: ");
            string fileName = Console.ReadLine() ?? throw new ArgumentNullException();
            var fr = new FileRepository();

            while (fr.FileExists(fileName))
            {
                Console.WriteLine("File with this name already exists...\nGo back to menu (0), or enter new name: ");
                fileName = Console.ReadLine() ?? throw new ArgumentNullException();
                if (fileName == "0")
                {
                    Menu();
                }
            }

            FileManager f = new FileManager(new FileProcessor(), fr);

            if (!f.DownloadFile(url, fileName).Result)
            {
                Console.WriteLine("Failed to download a file.\n");
                Menu();
            }
            Console.WriteLine("File downloaded successfully.\n");
            Menu();
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

        private static void FileExists()
        {

        }
    }
}
