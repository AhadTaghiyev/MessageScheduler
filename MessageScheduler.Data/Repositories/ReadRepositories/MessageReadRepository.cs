

using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Entities;
using MessageScheduler.Data.Contexs;

namespace MessageScheduler.Data.Repositories.ReadRepositories
{
    public class MessageReadRepository:ReadRepository<Message>,IMessageReadRepository
    {
        public MessageReadRepository(MessageSchedulerDbContext context):base(context) { }
    }
}
