using System;
using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class EditFriendViewModel
    {
        [Key]
        public Guid Id { get; set; }       

        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }  
    
    }
}
