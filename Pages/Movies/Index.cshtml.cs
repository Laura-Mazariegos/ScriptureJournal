using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public PaginatedList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        public string MovieSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string CurrentFilter, string SearchString, int? pageIndex)
        {
            // Use LINQ to get list of genres.
            CurrentSort = sortOrder;
            MovieSort = String.IsNullOrEmpty(sortOrder) ? "movie_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (SearchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            CurrentFilter = SearchString;

            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Chapter
                                            select m.Chapter;

            var movies = from m in _context.Movie
                         select m;

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(m => m.Book);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.LogDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.LogDate);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Book);
                    break;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Chapter == MovieGenre);
            }
            int pageSize = 5;

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await PaginatedList<Movie>.CreateAsync(movies.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
