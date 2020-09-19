using System;
using WhereIsMyGame.Collection.API.Models;

namespace WhereIsMyGame.Collection.API.Application.Dto
{
    public class AddGameDto
    {
        public Guid PlataformId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public byte[] Image { get; set; }

        public static Game ToGame(AddGameDto gameDto)
        {
            return new Game(gameDto.Name, gameDto.Description,
                gameDto.IsActive, gameDto.PlataformId, gameDto.UserId, DateTime.Now, gameDto.Image);
        }
    }
}
