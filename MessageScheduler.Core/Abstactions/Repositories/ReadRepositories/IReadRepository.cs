using MessageScheduler.Core.Entities.BaseEntities;
using System.Linq.Expressions;

namespace MessageScheduler.Core.Abstactions.Repositories.ReadRepositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression,string[] Includes=null);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression,bool IsTracking,string[] Includes=null);
    }
}
