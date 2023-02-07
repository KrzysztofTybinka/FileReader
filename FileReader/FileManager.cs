using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileManager
    {
        private FileProcessor fileProcessor;
        private FileRepository fileRepository;

        public FileManager(FileProcessor fileProcessor, FileRepository fileRepository)
        {
            this.fileProcessor = fileProcessor;
            this.fileRepository = fileRepository;
        }

        public async Task<bool> DownloadFile(string url, string fileName)
        {
            string content = await DownloadFileAsync(url);
            string fileType = GetFileType(url);
            var file = fileProcessor.DeserializeFile(content, fileName, fileType);

            if (!fileRepository.FileExists(fileName))
            {
                return fileRepository.SaveFile(file);
            }
            return false;
        }



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
