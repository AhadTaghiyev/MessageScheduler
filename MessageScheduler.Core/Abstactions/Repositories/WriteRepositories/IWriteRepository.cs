using MessageScheduler.Core.Entities.BaseEntities;
using System.Linq.Expressions;

namespace MessageScheduler.Core.Abstactions.Repositories.WriteRepositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity,new()
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<int> SaveAsync();
        public void Save();
    }
}
