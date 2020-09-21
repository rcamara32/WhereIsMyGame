using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Application.Dto;
using WhereIsMyGame.Collection.API.Data.Repositories;
using WhereIsMyGame.Collection.API.Models;

namespace WhereIsMyGame.Collection.API.Application.Services
{
    public class GameAppService : IGameAppService
    {
        private readonly IGameRepository _gameRepository;

        public GameAppService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<GameDto>> GetByUser(Guid userId)
        {
            var gamesCollection = await _gameRepository.GetByUser(userId);

            return gamesCollection.Select(x => new GameDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                Image = x.Image,
                IsActive = x.IsActive,
                IsLoaned = x.IsLoaned(),
                LastDateLoan = x.LastDateLoan(),
                UserId = x.UserId,
                Plataform = new PlataformDto
                {
                    Id = x.PlataformId,
                    Name = x.Plataform.Name,
                    Code = x.Plataform.Code
                }
            });
        }

        public async Task<GameDto> GetById(Guid id)
        {
            var game = await _gameRepository.GetById(id);

            if (game != null)
            {
                var gameDto = new GameDto()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Description = game.Description,

                    CreatedDate = game.CreatedDate,
                    Image = game.Image,
                    IsActive = game.IsActive,
                    IsLoaned = game.IsLoaned(),
                    LastDateLoan = game.LastDateLoan(),
                    UserId = game.UserId,
                    Plataform = new PlataformDto
                    {
                        Id = game.PlataformId,
                        Name = game.Plataform.Name,
                        Code = game.Plataform.Code
                    },
                    GameLoanHistory = game.Loans.Select(l => new GameLoanHistoryDto
                    {
                        CreatedDate = l.CreatedDate,
                        ReturnedDate = l.ReturnedDate,
                        FriendName = l.Friend.Name
                    }).ToList()
                };

                return gameDto;
            }

            return null;
        }

        public async Task<IEnumerable<PlataformDto>> GetAllPlataforms()
        {
            var plataforms = await _gameRepository.GetAllPlataforms();
            return plataforms.Select(x => new PlataformDto()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            });
        }

        public async Task<bool> AddGame(AddGameDto addGameDto)
        {
            var game = AddGameDto.ToGame(addGameDto);
            _gameRepository.Add(game);
            var result = await _gameRepository.UnitOfWork.Commit();

            return result;
        }

        public async Task<bool> EditGame(EditGameDto editGameDto)
        {
            var game = await _gameRepository.GetById(editGameDto.Id);

            if (game != null)
            {
                game.UpdateDetails(editGameDto.PlataformId, editGameDto.Name,
                        editGameDto.Description, editGameDto.IsActive, editGameDto.Image);

                _gameRepository.Update(game);
                return await _gameRepository.UnitOfWork.Commit();
            }

            return false;
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _gameRepository.GetById(id);

            if (game != null)
            {
                _gameRepository.Delete(game);
                return await _gameRepository.UnitOfWork.Commit();
            }

            return false;
        }

        public async Task<bool> MarkAsReturned(MarkReturnedDto markReturnedDto)
        {
            var game = await _gameRepository.GetById(markReturnedDto.GameId);

            if (game != null)
            {
                var loan = game.Loans.FirstOrDefault(c => !c.IsReturned);

                if (loan != null)
                {
                    game.Loans.Remove(loan);

                    loan.MarkAsReturned(loan.CreatedDate, markReturnedDto.ReturnedDate);
                    game.Loans.Add(loan);
                }

                _gameRepository.Update(game);
                return await _gameRepository.UnitOfWork.Commit();
            }

            return false;
        }

        public async Task<bool> GameLoan(GameLoanDto gameLoanDto)
        {
            var game = await _gameRepository.GetById(gameLoanDto.GameId);

            if (game != null)
            {
                var gameLoan = new Loan(gameLoanDto.GameId, gameLoanDto.FriendId, gameLoanDto.StartDate, null, false);
                _gameRepository.AddGameLoan(gameLoan);
                return await _gameRepository.UnitOfWork.Commit();
            }

            return false;
        }

    }
}
