using WhereIsMyGame.Core.DomainObjects;
using System;

namespace WhereIsMyGame.Core.Data
{
    public interface IRepositoryBase<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

}
