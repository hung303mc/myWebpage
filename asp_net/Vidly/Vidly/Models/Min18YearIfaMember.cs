using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearIfaMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            // membershipID = 1 
            if(customer.MembershipTypeId == MembershipType.Const.PayAsYouGo
                || customer.MembershipTypeId == MembershipType.Const.UnKnown)
            {
                return ValidationResult.Success;
            }

            // birthdate 
            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Age must > 18");

        }
        
    }
}