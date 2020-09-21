using System;
using System.Collections.Generic;

namespace WhereIsMyGame.BackFrondEnd.Loan.Models
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsLoaned { get; set; }
        public DateTime? LastDateLoan { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }

        public PlataformDto Plataform { get; set; }
        public ICollection<GameLoanHistoryDto> GameLoanHistory { get; set; }

    }
}
