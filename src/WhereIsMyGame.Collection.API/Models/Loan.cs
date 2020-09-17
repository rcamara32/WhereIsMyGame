using System;
using WhereIsMyGame.Core.DomainObjects;

namespace WhereIsMyGame.Collection.API.Models
{
    public class Loan : Entity
    {
        public Guid GameId { get; private set; }
        public Guid FriendId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsReturned { get; private set; }

        public Game Game { get; private set; }
        public Friend Friend { get; private set; }

        protected Loan() { }

        public Loan(Guid gameId, Guid friendId, DateTime createdDate, bool returned)
        {
            GameId = gameId;
            FriendId = friendId;
            CreatedDate = createdDate;
            IsReturned = returned;

            Validate();
        }
     
        public void Validate()
        {
            Validations.IfDifferent(GameId, Guid.Empty, "The Game cannot be empty");
            Validations.IfDifferent(FriendId, Guid.Empty, "You need to inform who is bowworing your game");            
        }

    }
}
