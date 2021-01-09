using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Susanin.Api.Contracts;

namespace Susanin.Api.Data
{
    public class RoadmapDbContext : DbContext
    { 
        public DbSet<RoadmapItem> Roadmap { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database/roadmap.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var converter = new ValueConverter<DateTime, string>(
                v => v.ToString("dd.MM.yyyy"),
                v => DateTime.ParseExact(v, "dd.MM.yyyy", new CultureInfo("ru-RU")));
            
            modelBuilder.Entity<RoadmapItem>()
                .Property(x => x.Created)
                .HasConversion(converter);
            
            var converter2 = new ValueConverter<DateTime?, string>(
                v => v == null ? null : v.Value.ToString("dd.MM.yyyy"),
                v => string.IsNullOrWhiteSpace(v) 
                    ? null
                    : DateTime.ParseExact(v, "dd.MM.yyyy", new CultureInfo("ru-RU")));
            
            modelBuilder.Entity<RoadmapItem>()
                .Property(x => x.Started)
                .HasConversion(converter2);
            
            modelBuilder.Entity<RoadmapItem>()
                .Property(x => x.PlannedComplete)
                .HasConversion(converter2);
            
            modelBuilder.Entity<RoadmapItem>()
                .Property(x => x.FactComplete)
                .HasConversion(converter2);
        }
    }
}