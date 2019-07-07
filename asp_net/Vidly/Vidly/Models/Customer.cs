using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Please enter customer name")]
        [StringLength(255)]
        [Display(Name = "Your name")]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type", Description = "my desciption")]
        public int MembershipTypeId { get; set; }

        [Min18YearIfaMember]
        public DateTime? Birthdate { get; set; }
    }
}