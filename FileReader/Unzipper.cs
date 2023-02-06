using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    /// <summary>
    /// Initilizes a new instance of the Unzipper class.
    /// Provides methods to unzip given files.
    /// </summary>
    public class Unzipper
    {
        private readonly byte[] file;

        public Unzipper(string url)
        {
            file = GetFile(url);
        }


        /// <summary>
        /// Unzips current file based on url and determines its type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>String representation of unzipped file.</returns>
        /// <exception cref="FileLoadException"></exception>
        public string UnzipTypeOut(out string type)
        {
            try
            {
                using (var zippedStream = new MemoryStream(file))
                {
                    using (var archive = new ZipArchive(zippedStream))
                    {
                        var entry = archive.Entries.FirstOrDefault();

                        if (entry is not null)
                        {
                            type = '.' + entry.FullName.Split('.').Last();

                            using (var unzippedEntryStream = entry.Open())
                            {
                                using (var ms = new MemoryStream())
                                {
                                    unzippedEntryStream.CopyTo(ms);
                                    var unzippedArray = ms.ToArray();

                                    return Encoding.Default.GetString(unzippedArray);
                                }
                            }
                        }
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                throw new FileLoadException("Cannot process the file.");
            }

        }

        /// <summary>
        /// Gets byte representation of current .zip file.
        /// </summary>
        /// <returns>Byte representation of current .zip file.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        private byte[] GetFile(string url)
        {
            try
            {
                using (WebClient zip = new WebClient())
                {
                    return zip.DownloadData(url);
                }
            }
            catch (Exception)
            {
                throw new FileNotFoundException("Cannot get file.");
            }
        }
    }
}
