using FileReader.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = FileReader.Files.File;

namespace FileReader
{
    /// <summary>
    /// Provides methods to manage database.
    /// </summary>
    public class FileRepository
    {
        /// <summary>
        /// Saves given file into a database.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>True if file was saved sccessfully, otherwise false.</returns>
        public bool SaveFile(File file)
        {
            try
            {
                using (var context = new FileContext())
                {
                    var f = new FileModel(file.FileName, file.Type, file.Content);

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

        /// <summary>
        /// Gets file from a database, based on given file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Proper file.</returns>
        public File GetFile(string fileName)
        {
            using (var context = new FileContext())
            {
                var file = context.Files.SingleOrDefault(x => x.Name == fileName);
                FileProcessor processor = new FileProcessor();
                File f = processor.DeserializeFile(file!.Content, file.Name, file.Type);
                return f;
            }
        }

        /// <summary>
        /// Deletes file from a database based on file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>True if file was deleted, otherwise false.</returns>
        public bool DeleteFile(string fileName)
        {
            try
            {
                using (var context = new FileContext())
                {
                    var objectToDelete = context.Files.SingleOrDefault(x => x.Name == fileName);
                    context.Files.Remove(objectToDelete!);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }    
        
        /// <summary>
        /// Gets list of all file names.
        /// </summary>
        /// <returns>List of file names.</returns>
        public List<string> GetFilesList()
        {
            using (var context = new FileContext())
            {
                return context.Files
                    .Select(n => n.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Checks if file with given file name exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True if file exists, otherwise false.</returns>
        public bool FileExists(string name)
        {
            using (var context = new FileContext())
            {
                bool exists = context.Files.Any(f => f.Name == name);
                if (exists)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
