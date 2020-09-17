using System.Threading.Tasks;

namespace WhereIsMyGame.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }

}
