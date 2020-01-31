using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.View_Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
        public ActionResult Index()
        {

            //if (String.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";
            //var peliculas = _context.Movies.Include(c => c.MovieGenre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");       


            return View("ReadOnlyList"/*peliculas*/);
        }


        [Authorize(Roles= RoleName.CanManageMovies)]
        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {

            //Acá dego Where. en vez de SingleOrDefault. para ver que onda
            var pelicula = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(c => c.Id == id);

            if (pelicula == null)
                return HttpNotFound();

            return View(pelicula);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var movieGenres = _context.MovieGenres.ToList();
            var viewModel = new MovieFormViewModel
            {
                MovieGenres = movieGenres
            };

            return View("MovieForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid) //Valido que lo ingresado esté en el formato requerido, sino recargo y muestro errores
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                   
                    MovieGenres = _context.MovieGenres.ToList()
                };

                return View("MovieForm", viewModel);

            };

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);


                // TryUpdateModel(customerInDb); esta linea es lo que te recomienda microsoft para hacer update con el formulario, pero tiene huecos de seguridad, pueden medianamente resolversse con parametros que traenotros problemas
                //Mapper.Map.(customer, customerInDb)

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.NumberInStock = movie.NumberInStock;


            }


            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null) //caso de no encontrar pelicula del id solicitado
                return HttpNotFound();
          
            
                var viewModel = new MovieFormViewModel(movie)
                {
                    MovieGenres = _context.MovieGenres.ToList()               

                   
                };

                return View("MovieForm", viewModel);                                       
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
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

  
   
       
        
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        ////Get: Movies/GetMovies
        //public IEnumerable<Vidly.Models.Movie> GetMovies()
        //{
        //    return new List<Movie>
        //         {
        //             new Movie {Id=1, Name = "Shrek" },
        //             new Movie {Id=2, Name = "Jarri Poter" },
        //             new Movie {Id=3, Name = "Mulán" },
        //             new Movie {Id=4, Name = "Chaqui Chan 34" },
        //             new Movie {Id=5, Name = "Frousen" },
        //         };
        //}

    } 
}