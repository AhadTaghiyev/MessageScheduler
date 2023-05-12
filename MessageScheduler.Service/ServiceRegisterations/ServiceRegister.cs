using FluentValidation.AspNetCore;
using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Abstactions.Repositories.WriteRepositories;
using MessageScheduler.Data.Contexs;
using MessageScheduler.Data.Repositories.ReadRepositories;
using MessageScheduler.Data.Repositories.WriteRepositories;
using MessageScheduler.Service.Dtos.MessageDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace MessageScheduler.Service.ServiceRegisterations
{
    public static class ServiceRegister
    {

        public static void AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MessagePostDto>()); ;
            services.AddDbContext<MessageSchedulerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IMessageWriteRepository, MessageWriteRepository>();
            services.AddScoped<IMessageReadRepository, MessageReadRepository>();
        }

    }
}
