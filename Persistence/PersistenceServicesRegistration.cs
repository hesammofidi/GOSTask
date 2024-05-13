using Application.Contract.Identity;
using Application.Contract.Persistance.Dapper;
using Application.Contract.Persistance.EFCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.IdentityConfig;
using Persistence.Repositories;
using Persistence.Repositories.Dapper;
using System.Data;

namespace Persistence
{

    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(configuration.GetConnectionString("DatabaseConection"));
            });
            services.AddIdentityServices(configuration);
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IProductDapperRepository, ProductDapperRepository>();
            services.AddScoped<IOrderDapperRepository, OrdersDapperRepository>();
            return services;
        }


    }
}
