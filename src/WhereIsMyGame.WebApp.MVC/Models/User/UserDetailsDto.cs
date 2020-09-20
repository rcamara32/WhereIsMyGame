using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WhereIsMyGame.Core.Communication;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class UserDetailsDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int QtdGamesBorrowed { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [DisplayName("Confirmed password")]
        [Compare("Password", ErrorMessage = "Pasword does not match")]
        public string ConfirmPassword { get; set; }


        public ResponseResult ResponseResult { get; set; }
    }
}
