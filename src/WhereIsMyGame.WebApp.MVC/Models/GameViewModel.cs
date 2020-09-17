using System;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }       
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
        public string Plataform { get; set; }
    }
}
