using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{

    public class Min0Max20MoviesIn : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            return (movie.NumberInStock >= 1 && movie.NumberInStock <= 20) ?
                 ValidationResult.Success : new ValidationResult("El numero de peliculas en Stock debe estar entre 1 y 20");
                      
        }



        }
   }
