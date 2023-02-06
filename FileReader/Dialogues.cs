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
        /// Starting method writing o console basic
        /// application information.
        /// </summary>
        public static void Start()
        {
            Console.WriteLine("File Reader is a command-line interface application that provides \n " +
                "methods to create files in different formats, download files from given url, " +
                "unzip, deserialize and/or read them. \n");
            Console.WriteLine();
            Console.WriteLine("Accessible file types: XML, JSON, CSV. (aslo in ZIP format)");
        }
    }
}
