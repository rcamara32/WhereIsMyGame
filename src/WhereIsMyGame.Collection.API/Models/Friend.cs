using System.Collections.Generic;
using WhereIsMyGame.Core.DomainObjects;

namespace WhereIsMyGame.Collection.API.Models
{
    public class Friend : Entity
    {
        public string Name { get; private set; }

        public ICollection<Loan> Loans { get; private set; }

        protected Friend() { }

        public Friend(string name)
        {
            Name = name;
            Validate();
        }

        public void Validate()
        {
            Validations.ValidateIsEmpty(Name, "Come on man, give a name to your friend");
        }

    }
}
