using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NChampions.Infra.Data.Context;


namespace NChampions.WebApi.Configurations
{
    public static class NChampionsContextConfigurations
    {
        public static IServiceCollection AddCustomDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped((provider) =>
            {
                return new DbContextOptionsBuilder<NChampionsContext>()
                .UseSqlServer(connection)
                .Options;
            });


            services.AddDbContext<NChampionsContext>();


            return services;
        }
    }
}
