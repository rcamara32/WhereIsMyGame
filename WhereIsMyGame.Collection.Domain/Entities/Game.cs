using System;
using WhereIsMyGame.Core.DomainObjects;

namespace WhereIsMyGame.Collection.Domain.Entities
{
    public class Game : Entity, IAggregateRoot
    {
        public Guid PlataformId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsLoan { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Image { get; private set; }

        public Plataform Plataform { get; private set; }

        protected Game() { }
        
        public Game(string name, string description, bool isLoan, bool isActive, Guid plataformId,
            DateTime createdDate, string image)
        {
            Name = name;
            Description = description;
            IsLoan = isLoan;
            IsActive = isActive;
            PlataformId = plataformId;
            CreatedDate = createdDate;
            Image = image;

            Validate();
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;

        public void ChangeCategory(Plataform plataform)
        {
            Plataform = plataform;
            PlataformId = plataform.Id;
        }

        public void ChangeDescription(string description)
        {
            Validations.ValidateIsEmpty(description, "The Game Description cannot be empty");
            Description = description;
        }

        public void Validate()
        {
            Validations.ValidateIsEmpty(Name, "The Game Name cannot be empty");
            Validations.ValidateIsEmpty(Description, "The Game Description cannot be empty");
            Validations.IfDifferent(PlataformId, Guid.Empty, "The Game Plataform Id cannot be empty");
            Validations.ValidateIsEmpty(Image, "The Game image cannot be empty");
        }

    }
}
