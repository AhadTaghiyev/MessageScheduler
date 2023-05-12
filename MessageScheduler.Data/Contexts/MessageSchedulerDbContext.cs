using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Data.Contexs
{
    public class MessageSchedulerDbContext : DbContext
    {
        public MessageSchedulerDbContext(DbContextOptions options):base(options) { }
       
    }
}
