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
                .Include(p => p.Loans)
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
            var game = await _context.Games
                .Include(b => b.Plataform)
                .Include(b => b.Loans)
                .ThenInclude(post => post.Friend)
                 .FirstOrDefaultAsync(b => b.Id == id);

            return game;
        }

        public void Add(Game game)
        {
            _context.Games.Add(game);
        }

        public void Add(Plataform plataform)
        {
            _context.Plataforms.Add(plataform);
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

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
