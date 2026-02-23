using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;
using System.Linq;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }

        public HomeController(MovieContext ctx) => context = ctx;

        public IActionResult Index()
        {
            // Aquí agregamos el .Include para que traiga los géneros junto con las películas
            var movies = context.Movies
                                .Include(m => m.Genre)
                                .OrderBy(m => m.Name)
                                .ToList();

            return View(movies);
        }
    }
}