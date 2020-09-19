using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Models;
using WhereIsMyGame.Core.Data;

namespace WhereIsMyGame.Collection.API.Data.Repositories
{
    public interface IFriendRepository : IRepositoryBase<Friend>
    {
        Task<Friend> GetById(Guid id);
        Task<IEnumerable<Friend>> GetByUser(Guid userId);
        void Add(Friend friend);
        void Update(Friend friend);
        void Delete(Friend friend);
    }

}
