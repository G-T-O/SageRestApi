using Infrastructure.Data.IDBAccess;
using Infrastructure.Data.DbAccess;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.IRepositories.Dapper;
using Infrastructure.IRepositories.Sage;
using Application.IServices;
using Application.Services;

namespace SageRestApi
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ISQLDataAccess, SQLDataAccess>();
            services.AddTransient<ISageAccess, SageAccess>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ISageClientRepository, SageClientRepository>();
            services.AddTransient<ISageInvoiceRepository, SageInvoiceRepository>();
            services.AddTransient<ISageOrderRepository, SageOrderRepository>();
            services.AddTransient<ISageOrderRepository, SageOrderRepository>();

            services.AddTransient<ISageClientService, SageClientService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ISageOrderService, SageOrderService>();
        }
    }
}
