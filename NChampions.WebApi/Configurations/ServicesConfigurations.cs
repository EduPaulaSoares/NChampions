using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NChampions.WebApi.Configurations
{
    public static class ServicesConfigurations
    {
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("NChampions.Application");
            services.AddMediatR(assembly);

            return services;
        }
    }
}
