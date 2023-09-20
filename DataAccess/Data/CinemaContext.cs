using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public class CinemaContext:DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MovieGenre>().HasKey(m => new { m.MovieID, m.GenreID });
            //modelBuilder.Entity<MovieGenre>().
            //    HasOne(c => c._Movie).
            //    WithMany(c => c.Genres).
            //    HasForeignKey(c => c.MovieID);
            //modelBuilder.Entity<MovieGenre>().
            //    HasOne(c => c._Genre).
            //    WithMany(c => c.Movies).
            //    HasForeignKey(c => c.GenreID);


            // ApplyConfigurations for Entities 
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaContext).Assembly);
            // or 
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            SeedData.SeedMovie(modelBuilder);
            SeedData.SeedGenre(modelBuilder);
            SeedData.SeedMovieGenre(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; } 
        public DbSet<MovieGenre> MoviesGenres { get; set; } 
    }
}
