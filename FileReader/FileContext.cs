using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    /// <summary>
    /// Represents database context.
    /// </summary>
    public class FileContext : DbContext
    {
        public DbSet<FileModel> Files { get; set; }

        /// <summary>
        /// Provides connection string, builds database.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KRZYSZTOF;Initial Catalog=Files;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
