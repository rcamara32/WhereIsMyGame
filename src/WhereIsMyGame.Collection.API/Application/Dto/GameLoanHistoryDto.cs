using System;

namespace WhereIsMyGame.Collection.API.Application.Dto
{
    public class GameLoanHistoryDto
    {
        public string FriendName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int QtdDaysLoan { get; set; }

    }
}
