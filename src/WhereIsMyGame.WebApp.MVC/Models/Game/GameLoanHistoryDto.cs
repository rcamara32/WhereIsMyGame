using System;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class GameLoanHistoryDto
    {
        public string FriendName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int QtdDaysLoan { get; set; }

    }
}
