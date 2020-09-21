using System;
using System.Collections.Generic;

namespace WhereIsMyGame.Collection.API.Application.Dto
{
    public class GameDto
    {
        public Guid Id { get; set; }        
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsLoaned { get; set; }
        public DateTime? LastDateLoan { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public byte[] Image { get; set; }

        public PlataformDto Plataform { get; set; }
        public ICollection<GameLoanHistoryDto> GameLoanHistory { get; set; }

    }
}
