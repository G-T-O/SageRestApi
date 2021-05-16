using Infrastructure.Data.IDBAccess;
using Infrastructure.Data.DbAccess;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.IRepositories.SQL;
using Infrastructure.IRepositories.Sage;
using Application.IServices;
using Application.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;
using System.Text.Json.Serialization;

namespace SageRestApi
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sage API",
                    Version = "v1"
                });

                c.EnableAnnotations();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddTransient<ISQLDataAccess, SQLDataAccess>();
            services.AddTransient<ISageAccess, SageAccess>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ISageClientRepository, SageClientRepository>();

            services.AddTransient<ISageInvoiceRepository, SageInvoiceRepository>();
            services.AddTransient<ISageOrderRepository, SageOrderRepository>();

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ISageOrderService, SageOrderService>();
        }
    }
}