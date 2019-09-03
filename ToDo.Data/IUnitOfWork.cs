using System.Threading.Tasks;

namespace Tasklist.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : Core.Models.BaseEntity;

        Task<int> Commit();

        void Rollback();
        void Save();
    }
}
