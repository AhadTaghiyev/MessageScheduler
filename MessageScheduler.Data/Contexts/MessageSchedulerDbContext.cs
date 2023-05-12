using MessageScheduler.Core.Entities;
using MessageScheduler.Core.Entities.BaseEntities;
using MessageScheduler.Data.Configurations.Message;
using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Data.Contexs
{
    public class MessageSchedulerDbContext : DbContext
    {
        public MessageSchedulerDbContext(DbContextOptions options):base(options) { }

        public DbSet<Message> Messages { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
        }

    }
}
