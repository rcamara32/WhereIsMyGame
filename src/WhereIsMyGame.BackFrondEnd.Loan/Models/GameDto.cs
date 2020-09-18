using System;

namespace WhereIsMyGame.BackFrondEnd.Loan.Models
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }

        public PlataformDto Plataform { get; set; }

    }
}
