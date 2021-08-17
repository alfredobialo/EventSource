using System.Threading.Tasks;

namespace EventSource
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<CommandResult> CreateNew(TEntity entity);
        Task<CommandResult> Update(TEntity entity);
        Task<CommandResult> Delete(TEntity entity);
    }
}