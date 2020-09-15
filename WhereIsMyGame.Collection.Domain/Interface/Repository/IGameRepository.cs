using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.Domain.Entities;
using WhereIsMyGame.Core.Data;

namespace WhereIsMyGame.Collection.Domain.Interface.Repository
{

    public interface IGameRepository : IRepositoryBase<Game>
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetById(Guid id);
        Task<IEnumerable<Game>> GetByPlataform(int code);
        Task<IEnumerable<Plataform>> GetAllPlataforms();

        void Add(Game game);
        void Update(Game game);

        void Add(Plataform plataform);
        void Update(Plataform plataform);

    }

}
