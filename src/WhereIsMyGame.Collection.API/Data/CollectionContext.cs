using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Models;
using WhereIsMyGame.Core.Data;
using WhereIsMyGame.Core.Messages;

namespace WhereIsMyGame.Collection.API.Data
{
    public class CollectionContext : DbContext, IUnitOfWork
    {

        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Plataform> Plataforms { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder
             .Model
             .GetEntityTypes()
             .SelectMany(e => e.GetProperties()
               .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollectionContext).Assembly);
        }

    }
}
