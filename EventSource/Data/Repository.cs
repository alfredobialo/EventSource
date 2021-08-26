using System;
using System.Threading.Tasks;
using EventSource.Core;
using EventSource.Domain;

namespace EventSource.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<CommandResult> CreateNew(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResult> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResult> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}