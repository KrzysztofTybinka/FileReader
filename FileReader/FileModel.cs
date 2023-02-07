using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    /// <summary>
    /// Represents file entity.
    /// </summary>
    public class FileModel
    {
        public FileModel(string name, string type, string content)
        {
            Name = name;
            Content = content;
            Type = type;
        }

        public int Id { get; set; }


        public string Name { get; set; }

        public string Type { get; set; }

        public string Content { get; set; }
    }
}
