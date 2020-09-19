using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class RegisterUser
    {
        [Required]
        [DisplayName("First Name")]        
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]        
        public string LastName { get; set; }      

        [Required]
        [EmailAddress(ErrorMessage = "{0} invalid format")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [DisplayName("Confirmed password")]
        [Compare("Password", ErrorMessage = "Pasword does not match")]
        public string ConfirmPassword { get; set; }
    }
}
