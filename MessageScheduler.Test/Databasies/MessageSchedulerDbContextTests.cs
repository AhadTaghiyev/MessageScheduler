using MessageScheduler.Core.Entities;
using MessageScheduler.Data.Contexs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageScheduler.Test.Databasies
{
    public class MessageSchedulerDbContextTests
    {
        private DbContextOptions<MessageSchedulerDbContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptions<MessageSchedulerDbContext>();
        }

        [Test]
        public async Task Test_SaveChangesAsync_Added()
        {
            using (var dbContext = new MessageSchedulerDbContext(_dbContextOptions))
            {
                var message = new Message
                {
                    To = "Taghiiyev.Ahad@gmail.com",
                    Content = "This is a test message.",
                    SendAt= DateTime.Now.AddDays(1),
                    Method="email"
                };
                dbContext.Messages.Add(message);
                await dbContext.SaveChangesAsync();
                Assert.AreEqual(DateTime.UtcNow.AddHours(4).Date, message.CreatedDate.Date);
            }
        }

        [Test]
        public async Task Test_SaveChangesAsync_Modified()
        {
            using (var dbContext = new MessageSchedulerDbContext(_dbContextOptions))
            {
                var message = new Message
                {
                    To = "Taghiiyev.Ahad@gmail.com",
                    Content = "This is a test message.",
                    SendAt = DateTime.Now.AddDays(1),
                    Method = "email"
                };
                dbContext.Messages.Add(message);
                await dbContext.SaveChangesAsync();
                message.Content = "Updated Test Message";
                await dbContext.SaveChangesAsync();
                Assert.AreEqual(DateTime.UtcNow.AddHours(4).Date, message.UpdatedDate.Date);
            }
        }
    }

}
