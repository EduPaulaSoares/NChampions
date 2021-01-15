using Microsoft.EntityFrameworkCore;
using NChampions.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace NChampions.Infra.Data.Context
{
    public class NChampionsContext : DbContext
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<Championship> Championship { get; set; }
        public DbSet<ChampionshipGame> ChampionshipGame { get; set; }
        public NChampionsContext([NotNull] DbContextOptions options) : base(options)
        {
        }

    }
}
