using MessageScheduler.Data.Contexs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace MessageScheduler.Service.ServiceRegisterations
{
    public static class ServiceRegister
    {
        public static void AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessageSchedulerDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }
    }
}
