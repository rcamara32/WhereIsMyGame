using System;

namespace WhereIsMyGame.BackFrondEnd.Loan.Models
{
    public class GameLoanDto
    {        
        public Guid GameId { get; set; }        
        public Guid FriendId { get; set; }        
        public DateTime StartDate { get; set; }        
    }
}
