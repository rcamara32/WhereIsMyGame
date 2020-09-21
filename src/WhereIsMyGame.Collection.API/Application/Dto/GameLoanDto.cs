using System;

namespace WhereIsMyGame.Collection.API.Application.Dto
{
    public class GameLoanDto
    {
        public Guid GameId { get; set; }
        public Guid FriendId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
