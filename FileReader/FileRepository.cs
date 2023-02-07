using FileReader.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileRepository
    {
        public void SaveFile(FileAbstract file)
        {
            using (var context = new FileContext())
            {
                var f = new FileModel(file.FileName, file.Content, file.Type);

                context.Files.Add(f);
                context.SaveChanges();
            }
        }

        //public FileAbstract GetFile(string fileName)
        //{
        //    using (var context = new FileContext())
        //    {
        //        var file = context.Files.Select(x => x.Name == fileName);
        //        FileAbstract f = new FileAbstract();
        //    }
        //}

        public bool FileExists(string name)
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
    }
}
