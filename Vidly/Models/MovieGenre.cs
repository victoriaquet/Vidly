using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MovieGenre
    {
        public int MovieGenreId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}