using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NChampions.Infra.Data.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NChampions.WebApi
{
    public class MigrationWorker : IHostedService
    {
        readonly IServiceProvider provider;
        public MigrationWorker(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = provider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<NChampionsContext>();
            await context.Database.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}