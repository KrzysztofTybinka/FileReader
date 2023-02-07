using FileReader.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = FileReader.Files.File;

namespace FileReader
{
    public class FileRepository
    {
        public bool SaveFile(File file)
        {
            try
            {
                using (var context = new FileContext())
                {
                    var f = new FileModel(file.FileName, file.Content, file.Type);

                    context.Files.Add(f);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public File GetFile(string fileName)
        {
            using (var context = new FileContext())
            {
                var file = context.Files.SingleOrDefault(x => x.Name == fileName);
                FileProcessor processor = new FileProcessor();
                File f = processor.DeserializeFile(file.Content, file.Name, file.Type);
                return f;
            }
        }

        public bool DeleteFile(string fileName)
        {
            try
            {
                using (var context = new FileContext())
                {
                    var objectToDelete = context.Files.SingleOrDefault(x => x.Name == fileName);
                    context.Files.Remove(objectToDelete);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }    
        
        public List<string> GetFilesList()
        {
            using (var context = new FileContext())
            {
                return context.Files
                    .Select(n => n.Name)
                    .ToList();
            }
        }

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
