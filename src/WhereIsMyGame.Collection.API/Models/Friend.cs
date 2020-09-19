using System;
using System.Collections.Generic;
using WhereIsMyGame.Core.DomainObjects;

namespace WhereIsMyGame.Collection.API.Models
{
    public class Friend : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Guid UserId { get; set; }

        public ICollection<Loan> Loans { get; private set; }

        protected Friend() { }

        public Friend(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
            Validate();
        }

        public void UpdateDetails(string name)
        {
            Name = name;
            Validate();
        }

        public void Validate()
        {
            Validations.ValidateIsEmpty(Name, "Come on man, give a name to your friend");
            Validations.ValidateIsNull(UserId, "UserId cannot be null");
        }

    }
}
