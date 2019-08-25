using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Please enter customer name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

//        [Min18YearIfaMember]
        public DateTime? Birthdate { get; set; }

    }
}