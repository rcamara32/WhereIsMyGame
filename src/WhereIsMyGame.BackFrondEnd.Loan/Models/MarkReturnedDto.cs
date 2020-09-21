using System;

namespace WhereIsMyGame.BackFrondEnd.Loan.Models
{
    public class MarkReturnedDto
    {
        public Guid GameId { get; set; }
        public DateTime ReturnedDate { get; set; }
    }
}
