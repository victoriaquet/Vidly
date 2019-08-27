using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if ( customer.MembershipTypeId == MembershipType.PayAsYouGo||customer.MembershipTypeId == MembershipType.Unknown) // si estamos en payAsYouGo o en Nada, la verificación de edad no es requerida
                return  ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("La fecha de nacimiento es requerida.");//solo en los casos que no son pay as you go

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("El cliente debe tener almenos 18 años");                       
        }

    }
}