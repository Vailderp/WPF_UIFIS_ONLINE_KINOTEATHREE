using Kinoteathree.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteathree
{
    internal class KinoContext : DbContext
    {
        public KinoContext() : base()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=kinodb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasOne(x => x.User).WithMany(t => t.Reviews).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>().HasOne(x => x.Film).WithMany(t => t.Reviews).HasForeignKey(x => x.FilmId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Film>().HasOne(x => x.Genre).WithMany(t => t.Films).HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Film>().HasOne(x => x.Country).WithMany(t => t.Films).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ActorFilmTable>().HasOne(x => x.Actor).WithMany(t => t.ActorFilmTables).HasForeignKey(x => x.ActorId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ActorFilmTable>().HasOne(x => x.Film).WithMany(t => t.ActorFilmTables).HasForeignKey(x => x.FilmId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Film>().HasOne(x => x.FilmVideo).WithOne(t => t.Film).HasForeignKey<FilmVideo>(x => x.FilmId);
            //modelBuilder.Entity<FilmVideo>().HasOne(x => x.Film).WithOne(t => t.FilmVideo).HasForeignKey<Film>(x => x.FilmVideoId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        //public DbSet<FilmVideo> FilmVideos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorFilmTable> ActorFilmTables { get; set; }
    }
}
