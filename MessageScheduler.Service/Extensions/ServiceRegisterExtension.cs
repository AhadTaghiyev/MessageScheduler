using FluentValidation.AspNetCore;
using Hangfire;
using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Abstactions.Repositories.WriteRepositories;
using MessageScheduler.Data.Contexs;
using MessageScheduler.Data.Repositories.ReadRepositories;
using MessageScheduler.Data.Repositories.WriteRepositories;
using MessageScheduler.Service.Dtos.MessageDto;
using MessageScheduler.Service.Profiles;
using MessageScheduler.Service.Services.Implementations;
using MessageScheduler.Service.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

namespace MessageScheduler.Service.ServiceRegisterations
{
    public static class ServiceRegisterExtension
    {

        public static void AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MessagePostDto>()); ;

            services.AddDbContext<MessageSchedulerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddHangfire(options =>
            {
                options.UseSqlServerStorage(configuration.GetConnectionString("Default"));
            });

            services.AddHangfireServer();
            services.AddScoped<IMessageWriteRepository, MessageWriteRepository>();
            services.AddScoped<IMessageReadRepository, MessageReadRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new MapProfile());
            });
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("Basic", _options =>
                {
                    _options.Window=TimeSpan.FromSeconds(12);
                    _options.PermitLimit = 4;
                    _options.QueueLimit = 5;
                    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });
            });
      



        }

    }
}
