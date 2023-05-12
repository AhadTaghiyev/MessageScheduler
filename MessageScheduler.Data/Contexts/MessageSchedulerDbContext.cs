using MessageScheduler.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Data.Contexs
{
    public class MessageSchedulerDbContext : DbContext
    {
        public MessageSchedulerDbContext(DbContextOptions options):base(options) { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow.AddHours(4),
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow.AddHours(4),
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
