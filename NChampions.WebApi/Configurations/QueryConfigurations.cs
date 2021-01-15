using Microsoft.Extensions.DependencyInjection;
using NChampions.Application.Queries;
using NChampions.Infra.Queries;

namespace NChampions.WebApi.Configurations
{
    public static class QueryConfigurations
    {
        public static IServiceCollection AddQueryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITeamQueries, TeamQueries>();
            services.AddScoped<IChampionshipQueries, ChampionshipQueries>();
            services.AddScoped<IChampionshipGameQueries, ChampionshipGameQueries>();
            services.AddScoped<IStandingQueries, StandingQueries>();



            return services;
        }
    }
}
