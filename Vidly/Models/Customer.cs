using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateTime? Birthday { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [ForeignKey("MembershipType")]
        [Display(Name = "Tipo de Membresía")]
        public byte MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

    }
}