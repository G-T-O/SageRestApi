using Application.Interfaces.Access;
using Application.Interfaces.Repositories;
using Core.Entities;
using Infrastructure.Data.DbAccess;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
