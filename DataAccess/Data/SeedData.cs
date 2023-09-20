using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static void SeedGenre(ModelBuilder model)
        {
            model.Entity<Genre>().HasData(new Genre[] {
                new Genre(){ Id = 1, Name = "Drama" },
                new Genre(){ Id = 2, Name = "Crime" },
                new Genre(){ Id = 3, Name = "Action" },
                new Genre(){ Id = 4, Name = "Adventure" },
                new Genre(){ Id = 5, Name = "History" },
                new Genre(){ Id = 6, Name = "Mistery" },
                new Genre(){ Id = 7, Name = "Thriller" },
            });
        }
        public static void SeedMovie(ModelBuilder model)
        {
            model.Entity<Movie>().HasData(new Movie[] {
                new Movie(){
                    Id = 1,
                    Title = "Main on Fire",
                    Year = 2004,
                    Description = "John, an ex-CIA officer, is entrusted with the responsibility of safeguarding an entrepreneur's daughter. When the girl gets kidnapped, John vows to seek revenge.",
                    Duration = new TimeSpan(2,26,00),
                },
                new Movie(){
                    Id = 2,
                    Title = "Gladiator",
                    Year = 2000,
                    Description = "Commodus takes over power and demotes Maximus, one of the preferred generals of his father, Emperor Marcus Aurelius. As a result, Maximus is relegated to fighting till death as a gladiator.",
                    Duration = new TimeSpan(2,35,00),
                },
                new Movie(){
                    Id = 3,
                    Title = "Only the Brave",
                    Year = 2017,
                    Description = "When a group of firefighters from California ignores a warning by Superintendent Eric Marsh about a wildfire, he decides to get his crew certified as wildfire hotshots.",
                    Duration = new TimeSpan(2,13,00),
                },
                new Movie(){
                    Id = 4,
                    Title = "Serenity",
                    Year = 2019,
                    Description = "Baker Dill is a fishing boat captain who leads tours off of the tranquil enclave of Plymouth Island. His peaceful life is soon shattered when his ex-wife Karen tracks him down. Desperate for help, Karen begs Baker to save her -- and their young son -- from her abusive husband. She wants him to take the brute out for a fishing excursion -- then throw him overboard to the sharks. Thrust back into a life that he wanted to forget, Baker now finds himself struggling to choose between right and wrong.",
                    Duration = new TimeSpan(1,46,00),
                },
                new Movie(){
                    Id = 5,
                    Title = "Unstoppable",
                    Year = 2010,
                    Description = "An unmanned, half-mile-long freight train hurtles towards a town at breakneck speed. An engineer and a young conductor, who happen to be on the same route, must race against time to try and stop it.",
                    Duration = new TimeSpan(1,38,00),
                },
            });
        }
        public static void SeedMovieGenre(ModelBuilder model)
        {
            model.Entity<MovieGenre>().HasData(new MovieGenre[] {
                new MovieGenre(){ MovieID = 1, GenreID = 1 },
                new MovieGenre(){ MovieID = 1, GenreID = 2 },
                new MovieGenre(){ MovieID = 1, GenreID = 3 },
                new MovieGenre(){ MovieID = 2, GenreID = 1 },
                new MovieGenre(){ MovieID = 2, GenreID = 4 },
                new MovieGenre(){ MovieID = 2, GenreID = 5 },
                new MovieGenre(){ MovieID = 3, GenreID = 1 },
                new MovieGenre(){ MovieID = 3, GenreID = 3 },
                new MovieGenre(){ MovieID = 4, GenreID = 1 },
                new MovieGenre(){ MovieID = 4, GenreID = 6 },
                new MovieGenre(){ MovieID = 4, GenreID = 7 },
                new MovieGenre(){ MovieID = 5, GenreID = 3 },
                new MovieGenre(){ MovieID = 5, GenreID = 7 },
            });
        }
    }
}
