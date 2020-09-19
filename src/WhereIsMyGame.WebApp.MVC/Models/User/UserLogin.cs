using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress(ErrorMessage = "{0} invalid format")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
