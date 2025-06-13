using MVCProject.Custom_Validation;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MVCProject.ViewModel.Auth
{
    public class RegisterViewModel
    {
        [Remote("checkusername" , "Account" , ErrorMessage = "User name must be at least 4 characters long.")]
       // [MinLength(4, ErrorMessage = "User name must be at least 4 characters long.")]
        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [MaxLength(14, ErrorMessage = "Maximum Number is 14 Digits")]
        [Unique]
        public string National_Number { get; set; }

        public bool IsLibrarian { get; set; } 
    }
}
