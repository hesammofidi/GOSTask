using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.IdentityConfig;

namespace Persistence
{

    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddIdentityServices(configuration);
            return services;
        }


    }
}
