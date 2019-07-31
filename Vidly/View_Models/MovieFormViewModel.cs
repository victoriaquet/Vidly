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
        public Movie Movie { get; set; }
        
    }
}