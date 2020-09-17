using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.WebApp.MVC.Models;

namespace WhereIsMyGame.WebApp.MVC.Services
{
    public interface ICollectionService
    {
        Task<IEnumerable<GameViewModel>> GetByUser();
        Task<GameViewModel> GetById(Guid id);
    }

    public interface ICollectionServiceRefit
    {
        [Get("games/")]
        Task<IEnumerable<GameViewModel>> GetByUser();

        [Get("game/{id}")]
        Task<GameViewModel> GetByid(Guid id);
    }
}