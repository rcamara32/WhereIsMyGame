using System.Collections.Generic;
using WhereIsMyGame.Core.DomainObjects;

namespace WhereIsMyGame.Collection.API.Models
{
    public class Plataform : Entity
    {
        public string Name { get; private set; }
        public int Code { get; private set; }

        public ICollection<Game> Games { get; set; }

        protected Plataform() { }
        public Plataform(string name, int code)
        {
            Name = name;
            Code = code;

            Validate();
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

        public void Validate()
        {
            Validations.ValidateIsEmpty(Name, "The Plataform Name cannot be empty");
            Validations.IfEquals(Code, 0, "The Plataform Code cannot be 0");
        }
    }
}
