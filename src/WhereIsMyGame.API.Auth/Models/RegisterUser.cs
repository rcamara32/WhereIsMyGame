using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.Auth.API.Models
{
    public class RegisterUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]        
        public string LastName { get; set; }       

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
