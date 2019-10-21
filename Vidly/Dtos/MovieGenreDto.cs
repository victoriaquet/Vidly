using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieGenreDto
    {
        public int MovieGenreId { get; set; }

       
        [Required]
        public string Name { get; set; }

    }
}