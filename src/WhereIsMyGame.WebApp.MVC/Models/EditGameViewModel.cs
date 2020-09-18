using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class EditGameViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid PlataformId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Image { get; set; }


        public IEnumerable<PlataformViewModel> Plataforms { get; set; }
    }
}
