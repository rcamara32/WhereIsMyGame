using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class NewFriendViewModel
    {                      
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }
    }
}
