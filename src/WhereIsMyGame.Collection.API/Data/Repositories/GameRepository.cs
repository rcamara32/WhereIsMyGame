using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Models;
using WhereIsMyGame.Core.Data;

namespace WhereIsMyGame.Collection.API.Data.Repositories
{
    public class GameRepository : IGameRepository
    {

        private readonly CollectionContext _context;

        public GameRepository(CollectionContext collectionContext)
        {
            _context = collectionContext;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Plataform>> GetAllPlataforms()
        {
            return await _context.Plataforms.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetByUser(Guid userId)
        {
            return await _context.Games.AsNoTracking()
                .Include(p => p.Plataform)
                .Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetByPlataform(int code)
        {
            return await _context.Games.AsNoTracking()
                .Include(p => p.Plataform)
                .Where(c => c.Plataform.Code == code).ToListAsync();
        }

        public async Task<Game> GetById(Guid id)
        {
            return await _context.Games
                .Include(o => o.Plataform)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Game game)
        {
            _context.Games.Add(game);
        }

        public void Add(Plataform plataform)
        {
            _context.Plataforms.Add(plataform);
        }

        public void Add(Friend friend)
        {
            _context.Friends.Add(friend);
        }

        public void Delete(Game game)
        {
            _context.Games.Remove(game);
        }


        public void Update(Game game)
        {
            _context.Games.Update(game);
        }

        public void Update(Plataform plataform)
        {
            _context.Plataforms.Update(plataform);
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
