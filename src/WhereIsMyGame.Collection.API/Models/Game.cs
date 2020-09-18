﻿using System;
using System.Collections.Generic;
using System.Linq;
using WhereIsMyGame.Core.DomainObjects;

namespace WhereIsMyGame.Collection.API.Models
{
    public class Game : Entity, IAggregateRoot
    {
        public Guid PlataformId { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }        
        public bool IsActive { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Image { get; private set; }


        public Plataform Plataform { get; private set; }
        public ICollection<Loan> Loans { get; private set; }

        protected Game() { }
        
        public Game(string name, string description, bool isActive, Guid plataformId,
            Guid userId, DateTime createdDate, string image)
        {
            Name = name;
            Description = description;          
            IsActive = isActive;
            PlataformId = plataformId;
            UserId = userId;
            CreatedDate = createdDate;
            Image = image;

            Validate();
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
        public void IsLoan() => Loans.Any(c => !c.IsReturned);

        public void UpdateDetails(Guid plataformId, string name, string description, bool isActive, string image)
        {                     
            PlataformId = plataformId;
            Name = name;
            Description = description;
            IsActive = isActive;
            Image = image;

            Validate();
        }

        public void Validate()
        {
            Validations.ValidateIsEmpty(Name, "The Game Name cannot be empty");
            Validations.ValidateIsEmpty(Description, "The Game Description cannot be empty");
            Validations.IfDifferent(PlataformId, Guid.Empty, "The Game Plataform Id cannot be empty");
            Validations.IfDifferent(UserId, Guid.Empty, "The User Id cannot be empty");
            Validations.ValidateIsEmpty(Image, "The Game image cannot be empty");
        }

    }
}
