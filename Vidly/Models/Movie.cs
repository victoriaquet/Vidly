using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre de la Película")]
        public string Name { get; set; } 
        

        [Required]
        [Display(Name = "Fecha de Lanzamiento")]
        public DateTime ReleaseDate { get; set; }
       
        public DateTime? DateAdded { get; set; }


        [Required]
        [Min0Max20MoviesIn]        
        [Display(Name = "Número en Stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Género de la Película")]
        public int MovieGenreId { get; set; }


        public MovieGenre MovieGenre { get; set; }

    }



}