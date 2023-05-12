using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Entities.BaseEntities;
using MessageScheduler.Data.Contexs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MessageScheduler.Data.Repositories.ReadRepositories
{
    public class ReadRepository<T> :IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly MessageSchedulerDbContext _context;
        public ReadRepository(MessageSchedulerDbContext context)=>_context = context;
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression,bool IsTracking, string[] Includes=null)
        {
            IQueryable<T> query=Table.Where(expression);

            if (!IsTracking)
                query = query.AsNoTrackingWithIdentityResolution();

            if (Includes != null)
            {
                foreach (string include in Includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression,string[] Includes=null)
        {
            IQueryable<T> query= Table.Where(expression);

            query.AsNoTrackingWithIdentityResolution();

            if (Includes != null)
            {
                foreach (string include in Includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}
