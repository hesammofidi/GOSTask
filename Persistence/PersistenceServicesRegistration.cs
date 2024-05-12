using Application.Contract.Identity;
using Application.Contract.Persistance.SystemsRolesManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.IdentityConfig;
using Persistence.Repositories;

namespace Persistence
{

    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            return services;
        }


    }
}
