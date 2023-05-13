using Hangfire.Common;
using MessageScheduler.Service.Services.Interfaces;
using System.Linq.Expressions;

namespace MessageScheduler.Service.BackGroundJobs
{
    public class MessageJob
    {

        public static async Task<string> SedMessage(Expression<Action> sendExpression, DateTime dateTime)
        {
            TimeSpan timeDifference = dateTime - DateTime.UtcNow;
            var JobId = Hangfire.BackgroundJob.Schedule(sendExpression, timeDifference);
            return JobId;
        }

        public static async Task DeleteMessage(string id)
        {
            Hangfire.BackgroundJob.Delete(id);
        }



    }
}
