using MessageScheduler.Service.Services.Interfaces;
using System.Linq.Expressions;

namespace MessageScheduler.Service.BackGroundJobs
{
    public class MessageJob
    {

        public static async Task SedMessage(Expression<Action> sendExpression, DateTime dateTime)
        {
            TimeSpan timeDifference = dateTime - DateTime.UtcNow;
            Hangfire.BackgroundJob.Schedule(sendExpression,timeDifference);
        }
    }
}
