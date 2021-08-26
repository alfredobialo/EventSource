using System.Threading.Tasks;
using EventSource.Core;
using EventSource.Domain;

namespace EventSource.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<CommandResult> CreateNew(TEntity entity);
        Task<CommandResult> Update(TEntity entity);
        Task<CommandResult> Delete(TEntity entity);
    }
}