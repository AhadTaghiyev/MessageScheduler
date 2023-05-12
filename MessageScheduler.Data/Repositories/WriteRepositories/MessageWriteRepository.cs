

using MessageScheduler.Core.Abstactions.Repositories.WriteRepositories;
using MessageScheduler.Core.Entities;
using MessageScheduler.Data.Contexs;

namespace MessageScheduler.Data.Repositories.WriteRepositories
{
    public class MessageWriteRepository:WriteRepository<Message>,IMessageWriteRepository
    {
        public MessageWriteRepository(MessageSchedulerDbContext context):base(context) { }
    }
}
