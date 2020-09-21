using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Models;
using WhereIsMyGame.Core.Data;

namespace WhereIsMyGame.Collection.API.Data.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        Task<Game> GetById(Guid id);
        Task<IEnumerable<Game>> GetByUser(Guid userId);
        Task<IEnumerable<Game>> GetByPlataform(int code);
        Task<IEnumerable<Plataform>> GetAllPlataforms();

        void Add(Game game);
        void Update(Game game);
        void Delete(Game game);

        void Add(Plataform plataform);
        void Update(Plataform plataform);


        void AddGameLoan(Loan loan);
    }

}
