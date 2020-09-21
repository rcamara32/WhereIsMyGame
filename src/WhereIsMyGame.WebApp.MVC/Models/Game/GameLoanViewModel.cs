using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class GameLoanViewModel
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public Guid GameId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid FriendId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime StartDate { get; set; }

        public IEnumerable<FriendViewModel> Friends { get; set; }

    }
}
