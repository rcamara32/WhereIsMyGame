﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Application.Dto;

namespace WhereIsMyGame.Collection.API.Application.Services
{
    public interface IGameAppService
    {
        Task<IEnumerable<GameDto>> GetByUser(Guid userId);
        Task<GameDto> GetById(Guid id);
        Task<IEnumerable<PlataformDto>> GetAllPlataforms();
        Task<bool> AddGame(AddGameDto addGameDto);
        Task<bool> EditGame(EditGameDto editGameDto);
        Task<bool> DeleteGame(Guid id);
        Task<bool> MarkAsReturned(MarkReturnedDto markReturnedDto);
        Task<bool> GameLoan(GameLoanDto gameLoanDto);
    }
}
