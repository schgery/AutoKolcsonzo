using AutokolcsonzoLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokolcsonzoLibrary.Services
{
    internal class AutokolcsonzoDbContext : DbContext
    {
        string c = "Server=localhost;Database=autokolcsonzo_gyakorlat;Uid=root;Pwd=;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(c, ServerVersion.AutoDetect(c));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>().ToTable("autok");
            modelBuilder.Entity<Berles>().ToTable("berlesek");
            modelBuilder.Entity<Gyarto>().ToTable("gyartok");
            modelBuilder.Entity<Kategoria>().ToTable("kategoriak");
            modelBuilder.Entity<Ugyfel>().ToTable("ugyfelek");

            modelBuilder.Entity<Auto>()
                .HasOne(a => a.Kategoria)
                .WithMany(g => g.Autok)
                .HasForeignKey(a => a.KategoriaId);

            modelBuilder.Entity<Auto>()
                .HasOne(a => a.Gyarto)
                .WithMany(g => g.Autok)
                .HasForeignKey(a => a.GyartoId);

            modelBuilder.Entity<Berles>()
                .HasOne(a => a.Ugyfel)
                .WithMany(g => g.Berlesek)
                .HasForeignKey(a => a.UgyfelId);

            modelBuilder.Entity<Berles>()
                .HasOne(a => a.Auto)
                .WithMany(g => g.Berlesek)
                .HasForeignKey(a => a.AutoId);
        }

        public DbSet<Auto> autok { get; set; }
        public DbSet<Ugyfel> ugyfelek { get; set; }
        public DbSet<Berles> berlesek { get; set; }
        public DbSet<Kategoria> kategoriak { get; set; }
        public DbSet<Gyarto> gyartok { get; set; }
    }
}
