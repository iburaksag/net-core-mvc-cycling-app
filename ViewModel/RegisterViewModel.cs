using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RunGroopWebApp.ViewModel
{
	public class RegisterViewModel
	{
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Password confirmation is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

