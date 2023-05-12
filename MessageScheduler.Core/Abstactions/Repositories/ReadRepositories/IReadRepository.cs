using MessageScheduler.Core.Entities.BaseEntities;
using System.Linq.Expressions;

namespace MessageScheduler.Core.Abstactions.Repositories.ReadRepositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        public Task<IQueryable<T>> GetAll();
        public Task<T> Get(Expression<Func<T, bool>> expression);
    }
}
