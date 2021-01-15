using Microsoft.Extensions.DependencyInjection;
using NChampions.Domain.Repositories;
using NChampions.Infra.Repositories;

namespace NChampions.WebApi.Configurations
{
    public static class RepositoryConfigurations
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
            services.AddScoped<IChampionshipGameRepository, ChampionshipGameRepository>();

            return services;
        }
    }
}