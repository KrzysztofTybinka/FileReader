using FileReader.Files;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using File = FileReader.Files.File;

namespace FileReader
{
    /// <summary>
    /// Provides methods that provide user dialogues,
    /// collecting input data from users and managing it.
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
            Console.Write("----- Menu ------\nChoose one option:\n0. Exit\n1. Download file\n2. Open file" +
                "\n3. Create file\n4. Show files\n5. Delete file\nEnter a number: ");

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
                        DeleteFile();
                        break;

                    case "6":
                        break;

                    default:
                        Console.WriteLine("Option not supported. Try again...");
                        continue;
                }

            }
        }

        /// <summary>
        /// Manages user dialog to download file, collects
        /// input data, downloads file and handles errors.
        /// </summary>
        private static void DownloadFile()
        {
            try
            {
                Console.Write("\nYou chose to download a file.\nEnter url: ");
                string url = Console.ReadLine() ?? throw new ArgumentNullException();
                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine() ?? throw new ArgumentNullException();
                var fr = new FileRepository();

                while (fr.FileExists(fileName))
                {
                    Console.Write("File with this name already exists...\nGo back to menu (0), or enter new name: ");
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
            catch (Exception)
            {
                Console.WriteLine("Something went wrong...\n");
                Menu();
            }
        }

        /// <summary>
        /// Manages user dialog to open a file, collects
        /// input data, opens file and handles errors.
        /// </summary>
        private static void OpenFile()
        {
            Console.Write("\nYou chose to open a file.\nEnter file name: ");
            string? fileName = Console.ReadLine();
            var fr = new FileRepository();

            while (fileName == null)
            {
                Console.Write("File name can't be empty, go back to menu (0) or enter file name: ");
                fileName = Console.ReadLine();

                if (fileName == "0")
                {
                    Menu();
                }
            }

            if (!fr.FileExists(fileName))
            {
                Console.WriteLine("File doesn't exist.\n");
                Menu();
            }
            File file = fr.GetFile(fileName);
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine(file.Serialize());
            Console.WriteLine();
            Menu();
        }

        /// <summary>
        /// Manages user dialog to create a file, collects
        /// input data, creates a file and handles errors.
        /// </summary>
        private static void CreateFile()
        {
            Console.Write("\nYou chose to create a file.\nEnter file name: ");
            string? fileName = Console.ReadLine();
            var fr = new FileRepository();
            var fp = new FileProcessor();
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

            while (fileName == null)
            {
                Console.Write("File name can't be empty, go back to menu (0) or enter file name: ");
                fileName = Console.ReadLine();

                if (fileName == "0")
                {
                    Menu();
                }
            }

            Console.Write("Enter file type: ");
            string? fileType = Console.ReadLine();

            while (fileType == null)
            {
                Console.Write("File type can't be empty, go back to menu (0) or enter file type: ");
                fileType = Console.ReadLine();

                if (fileName == "0")
                {
                    Menu();
                }
            }

            Console.WriteLine("You are in a creation mode.\nIf you want to create file, press enter without entering any value.");
            while (true)
            {
                Console.Write("Enter key name: ");
                string? key = Console.ReadLine();

                if (String.IsNullOrEmpty(key))
                    break;

                Console.Write("Enter value: ");
                string? value = Console.ReadLine();

                if (String.IsNullOrEmpty(value))
                    break;

                if (data.TryAdd(key, new List<string>() { value }))
                {
                    data[key].Add(value);
                }
            }

            try
            {
                File file = fp.CreateFile(fileName, fileType, data);
                fr.SaveFile(file);
                Console.WriteLine("File created and saved.\n");
                Menu();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
                Menu();
            }
        }

        private static void ShowFiles()
        {
            try
            {
                Console.WriteLine("\nFiles list:");
                var fr = new FileRepository();
                var files = fr.GetFilesList();

                foreach (var fileName in files)
                {
                    Console.WriteLine(fileName);
                }
                Console.WriteLine();
                Menu();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong...\n");
                Menu();
            }
        }

        /// <summary>
        /// Manages user dialog to delete file, collects
        /// input data, deletes file and handles errors.
        /// </summary>
        private static void DeleteFile()
        {
            Console.Write("\nYou chose to delete a file.\nEnter file name: ");
            string? fileName = Console.ReadLine();
            var fr = new FileRepository();

            while (fileName == null)
            {
                Console.Write("File name can't be empty, go back to menu (0) or enter file name: ");
                fileName = Console.ReadLine();

                if (fileName == "0")
                {
                    Menu();
                }
            }

            if (!fr.FileExists(fileName))
            {
                Console.WriteLine("File doesn't exist.\n");
                Menu();
            }
            fr.DeleteFile(fileName);
            Console.WriteLine("File deleted successfully.\n");
            Menu();
        }
    }
}
