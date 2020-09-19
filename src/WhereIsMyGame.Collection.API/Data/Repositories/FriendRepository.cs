using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Models;
using WhereIsMyGame.Core.Data;

namespace WhereIsMyGame.Collection.API.Data.Repositories
{
    public class FriendRepository : IFriendRepository
    {

        private readonly CollectionContext _context;

        public FriendRepository(CollectionContext collectionContext)
        {
            _context = collectionContext;
        }

        public IUnitOfWork UnitOfWork => _context;      

        public async Task<IEnumerable<Friend>> GetByUser(Guid userId)
        {
            return await _context.Friends.AsNoTracking()
                //.Include(p => p.Loans)
                .Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<Friend> GetById(Guid id)
        {
            return await _context.Friends
                //.Include(o => o.Loans)
                .FirstOrDefaultAsync(i => i.Id == id);
        }       

        public void Add(Friend friend)
        {
            _context.Friends.Add(friend);
        }

        public void Delete(Friend friend)
        {
            _context.Friends.Remove(friend);
        }
               

        public void Update(Friend friend)
        {
            _context.Friends.Update(friend);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
