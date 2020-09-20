using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.Core.Communication;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Services
{
    public interface ICollectionService
    {
        Task<IEnumerable<GameViewModel>> GetByUser();
        Task<GameViewModel> GetById(Guid id);
        Task<IEnumerable<PlataformViewModel>> GetAllPlataforms();

        Task<ResponseResult> AddGame(NewGameViewModel newGameViewModel);
        Task<ResponseResult> EditGame(EditGameViewModel editGameViewModel);
        Task<ResponseResult> DeleteGame(Guid id);
        Task<ResponseResult> MarkAsReturned(MarkReturnedDto markReturnedDto);
    }

    public interface ICollectionServiceRefit
    {
        [Get("games/")]
        Task<IEnumerable<GameViewModel>> GetByUser();

        [Get("game/{id}")]
        Task<GameViewModel> GetByid(Guid id);

        [Get("games/plataforms")]
        Task<IEnumerable<PlataformViewModel>> GetAllPlataforms();

        [Post("games/new-game")]
        Task<ResponseResult> AddGame(NewGameViewModel newGameViewModel);

        [Put("games/edit-game")]
        Task<ResponseResult> EditGame(EditGameViewModel editGameViewModel);

        [Delete("games/delete-game")]
        Task<ResponseResult> DeleteGame(Guid id);

        [Put("games/mark-returned")]
        Task<ResponseResult> MarkAsReturned(MarkReturnedDto markReturnedDto);
    }
}