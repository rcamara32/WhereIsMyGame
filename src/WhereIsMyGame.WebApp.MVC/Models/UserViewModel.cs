using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress(ErrorMessage = "{0} invalid formast")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [DisplayName("Confirmed password")]
        [Compare("Password", ErrorMessage = "Pasword does not match")]
        public string ConfirmPassword { get; set; }
    }

    public class UserLogin
    {
        [Required]
        [EmailAddress(ErrorMessage = "{0} invalid format")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class GetUserLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }

    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
