using System;

namespace WhereIsMyGame.Collection.API.Application.Dto
{
    public class MarkReturnedDto
    {
        public Guid GameId { get; set; }
        public DateTime ReturnedDate { get; set; }
    }
}
