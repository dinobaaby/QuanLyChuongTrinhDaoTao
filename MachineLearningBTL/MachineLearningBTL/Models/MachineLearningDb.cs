using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MachineLearningBTL.Models
{
    public class MachineLearningDb : DbContext
    {
        public DbSet<DiaBetes> DiaBetes { get; set; }
        public DbSet<UserData> userDatas { get; set; }
        public DbSet<Weather> weathers { get; set; }

        public MachineLearningDb(DbContextOptions<MachineLearningDb> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       
    }
}