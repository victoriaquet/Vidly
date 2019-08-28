using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.View_Models
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> MovieGenres { get; set; }
        public int? Id { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre de la Película")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Fecha de Lanzamiento")]
        public DateTime? ReleaseDate { get; set; }



        [Required]
        [Min0Max20MoviesIn]
        [Display(Name = "Número en Stock")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Género de la Película")]
        [Required]
        public int? MovieGenreId { get; set; }
       

        public string Title
        {
            get
            {
                return Id != 0 ? "Editar Pelicula" : "Nueva Pelicula";    
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            MovieGenreId = movie.MovieGenreId;

        }



    }
}