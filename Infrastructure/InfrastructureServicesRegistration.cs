using Domain.Users;
using Infrastructure.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services
          , IConfiguration configuration)
        {
            services.AddTransient<IEmailSender<DomainUser>, SendEmail>();

            return services;
        }
    }
}
