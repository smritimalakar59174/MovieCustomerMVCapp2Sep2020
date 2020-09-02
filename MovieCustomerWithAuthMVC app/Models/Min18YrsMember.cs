using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerWithAuthMVC_app.Models
{
    public class Min18YrsMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer =(Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.DOB == null)
                return new ValidationResult("Birthdate is Required");
            var age = DateTime.Today.Year - customer.DOB.Date.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer age should be more than 18 year");
           // return base.IsValid(value, validationContext);
        }
    }
}