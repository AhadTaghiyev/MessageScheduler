using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Entities.BaseEntities;
using MessageScheduler.Data.Contexs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MessageScheduler.Data.Repositories.ReadRepositories
{
    public class ReadRpository<T> :IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly MessageSchedulerDbContext _context;
        public ReadRpository(MessageSchedulerDbContext context)=>_context = context;
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> Get(Expression<Func<T, bool>> expression,bool IsTracking)
        {
            IQueryable<T> query=Table.Where(expression);

            if (!IsTracking)
                query = query.AsNoTrackingWithIdentityResolution();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return Table.AsQueryable();
        }
    }
}
