using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentClass.ViewModels.UserPass
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is not set!")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is not set!")]
        public string? LastName { get; set; }

        [Remote(action: "IsEmailNotExist", controller: "Home", ErrorMessage = "Email already used!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email not valid!")]
        [Required(ErrorMessage = "Email is not set!")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is not set!")]       
        public string? Pass { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Pass", ErrorMessage = "Password do not match.")]
        public string? ConfirmPass { get; set; }
        public bool InviteCode { get; set; }
    }
}
