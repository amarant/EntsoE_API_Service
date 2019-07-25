using EntsoE_DataModel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntsoE_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=MarketDataDb;Trusted_Connection=True;",
                            options => options.EnableRetryOnFailure());
        }

        public DbSet<GenForecastLog> GenForecastRequestLogs { get; set; }

        public DbSet<GenForecastMeta> GenForecastMeta { get; set; }
        public DbSet<GenForecastTimeSeries> GenForecastTimesSeries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<GenForecastLog>()
            .Property(e => e.InsertedOn)
            .HasDefaultValueSql("getdate()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
