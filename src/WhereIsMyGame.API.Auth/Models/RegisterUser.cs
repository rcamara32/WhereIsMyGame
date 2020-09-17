using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.Auth.API.Models
{
    public class RegisterUser
    {        

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmedEmail { get; set; }
    }
}
