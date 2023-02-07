using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    /// <summary>
    /// Provides methods to download and analize files.
    /// </summary>
    public class FileManager
    {
        private FileProcessor fileProcessor;
        private FileRepository fileRepository;

        public FileManager(FileProcessor fileProcessor, FileRepository fileRepository)
        {
            this.fileProcessor = fileProcessor;
            this.fileRepository = fileRepository;
        }

        /// <summary>
        /// Donwloads asynchronously file from given url
        /// address and saves it to a database.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <returns>True if file was downloaded and saved 
        /// successfully, otherwise false.</returns>
        public async Task<bool> DownloadFile(string url, string fileName)
        {
            string fileType = GetFileType(url);
            string content;

            if (fileType == ".zip")
            {
                Unzipper uz = new Unzipper(url);
                content = uz.UnzipTypeOut(out fileType);                
            }
            else
            {
                content = await DownloadFileAsync(url);
            }

            var file = fileProcessor.DeserializeFile(content, fileName, fileType);

            if (!fileRepository.FileExists(fileName))
            {
                return fileRepository.SaveFile(file);
            }
            return false;
        }

        /// <summary>
        /// Downloads file asynchronously from given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>String representation of downloaded file.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private async Task<string> DownloadFileAsync(string url)
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

        /// <summary>
        /// Gets file type based on given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>String representation of file type.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private string GetFileType(string url)
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
