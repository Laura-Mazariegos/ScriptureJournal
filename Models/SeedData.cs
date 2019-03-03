using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Book = "When Harry Met Sally",
                        LogDate = DateTime.Parse("1989-2-12"),
                        Chapter = "Romantic Comedy",
                        Scripture = 7.99M,
                        Notes = "R"
                    },

                    new Movie
                    {
                        Book = "Ghostbusters ",
                        LogDate = DateTime.Parse("1984-3-13"),
                        Chapter = "Comedy",
                        Scripture = 8.99M,
                        Notes = "G"
                    },

                    new Movie
                    {
                        Book = "Ghostbusters 2",
                        LogDate= DateTime.Parse("1986-2-23"),
                        Chapter = "Comedy",
                        Scripture = 9.99M,
                        Notes = "G"
                    },

                    new Movie
                    {
                        Book = "Rio Bravo",
                        LogDate = DateTime.Parse("1959-4-15"),
                        Chapter = "Western",
                        Scripture = 3.99M,
                        Notes = "NA"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
