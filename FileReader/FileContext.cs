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
        public DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KRZYSZTOF;Initial Catalog=Files;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
