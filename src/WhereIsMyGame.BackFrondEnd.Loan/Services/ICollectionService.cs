using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.BackFrondEnd.Loan.Models;
using WhereIsMyGame.Core.Communication;

namespace WhereIsMyGame.BackFrondEnd.Loan.Services
{
    public interface ICollectionService
    {
        Task<IEnumerable<GameDto>> GetByUser();
        Task<GameDto> GetById(Guid id);
        Task<IEnumerable<PlataformDto>> GetAllPlataforms();
        Task<ResponseResult> AddGame(AddGameDto addGameDto);
    }
}
