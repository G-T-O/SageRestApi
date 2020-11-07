using Application.Interfaces.Access;
using Application.Interfaces.Sage.Repositories;
using Application.Interfaces.Repositories;
using Infrastructure.Data.DbAccess;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Services;
using Application.Services;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDapperAccess, DapperAccess>();
            services.AddTransient<ISageAccess, SageAccess>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ISageClientRepository, SageClientRepository>();
            services.AddTransient<ISageInvoiceRepository, SageInvoiceRepository>();
            services.AddTransient<ISageOrderRepository, SageOrderRepository>();

            services.AddTransient<ISageClientService, SageClientService>();
            services.AddTransient<IClientService, ClientService>();
        }
    }
}
