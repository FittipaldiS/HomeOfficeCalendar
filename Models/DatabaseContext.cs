using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HomeOffice.Calendar.Models
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {

            //var dpath = @"C:\Users\Fitti\source\repos\FittipaldiS\Portfolio.SimoneFittipaldi\WPF\HomeOffice.Calendar\DatabaseLite\HomeOfficeDayData";
            //optionsBuilder.UseSqlite($"Data Source = {dpath}");

            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            string databaseFolderPath = Path.Combine(projectDirectory, "DatabaseLite");

            if (!Directory.Exists(databaseFolderPath))
            {
                Directory.CreateDirectory(databaseFolderPath);
            }

            string databasePath = Path.Combine(databaseFolderPath, "HomeOfficeDayData.db");

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurazione del mapping delle entità usando Fluent API
            modelBuilder.Entity<HomeOfficeInfo>(entity =>
            {
                // Configura la chiave primaria
                entity.HasKey(e => e.Id);

                // Configura il nome della tabella
                entity.ToTable("HomeOfficeInfo");

                // Configura le proprietà
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Holiday);
                entity.Property(e => e.SickDay);
                entity.Property(e => e.PublicHoliday);
                entity.Property(e => e.HomeOfficePercent);
                entity.Property(e => e.Workday);
                entity.Property(e => e.DayInHomeOffice);
                entity.Property(e => e.DayInOffice);
            });
        }

        public DbSet<HomeOfficeInfo> HomeOfficeInfos { get; set; }
    }
}
