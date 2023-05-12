

using MessageScheduler.Core.Abstactions.Repositories.WriteRepositories;
using MessageScheduler.Core.Entities.BaseEntities;
using MessageScheduler.Data.Contexs;
using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Data.Repositories.WriteRepositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly MessageSchedulerDbContext _context;
        public WriteRepository(MessageSchedulerDbContext context) => _context = context;

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public int Save()
        {
           return  _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
        }
    }
}
