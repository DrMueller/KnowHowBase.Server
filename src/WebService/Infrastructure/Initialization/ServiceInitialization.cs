using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Khb.Common.ApplicationSettings.Models;

namespace Mmu.Khb.WebService.Infrastructure.Initialization
{
    internal static class ServiceInitialization
    {
        internal static IServiceProvider InitializeServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            InitializeAutoMapper(services);
            InitializeAppSettings(services, configuration);
            InitializeCors(services);

            var result = IocInitialization.InitializeIoc(services);
            return result;
        }

        private static void InitializeAppSettings(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionName));
            services.AddSingleton(configuration);
        }

        private static void InitializeAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper();
        }

        private static void InitializeCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
                });
        }
    }
}