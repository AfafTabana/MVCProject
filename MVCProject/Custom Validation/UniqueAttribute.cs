using MVCProject.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MVCProject;


namespace MVCProject.Custom_Validation
{
    public class UniqueAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string nationalNumber = value?.ToString();

         
            var context = (LibraryContext)validationContext.GetService(typeof(LibraryContext));

            if (context == null)
            {
                return new ValidationResult("Database context is not available.");
            }

            bool existsInLibrarians = context.Librarians.Any(e => e.National_Number == nationalNumber);
            bool existsInUsers = context.Users.Any(e => e.National_Number == nationalNumber);

            if (!existsInLibrarians && !existsInUsers)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("National Number must be unique.");
        }


    }
}
