using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.View_Models;
using System.Data.Entity;

namespace Vidly.Controllers
    
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        //Necesito inicilizar el atributo (variable) anterior, lo hago en el ctor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

      


        //Controlador de la vista Index de Movies -> Movies/Index
        public ActionResult Index( string sortBy)
        {
       
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            var peliculas = _context.Movies.Include(c=> c.MovieGenre).ToList();

            return View(peliculas);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {

            //Acá dego Where. en vez de SingleOrDefault. para ver que onda
            var pelicula = _context.Movies.Include(c=> c.MovieGenre).SingleOrDefault(c=> c.Id == id);

            if (pelicula == null)
                return HttpNotFound();
            
            return View(pelicula);
        }



        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        // GET: Movies/Edit/id 
        // GET: Movies/Edit?id=number
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

       
        
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //Get: Movies/GetMovies
        public IEnumerable<Vidly.Models.Movie> GetMovies()
        {
            return new List<Movie>
                 {
                     new Movie {Id=1, Name = "Shrek" },
                     new Movie {Id=2, Name = "Jarri Poter" },
                     new Movie {Id=3, Name = "Mulán" },
                     new Movie {Id=4, Name = "Chaqui Chan 34" },
                     new Movie {Id=5, Name = "Frousen" },
                 };
        }

    } 
}