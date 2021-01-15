using NChampions.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChampions.Application.Queries
{
    public interface IChampionshipGameQueries
    {
        Task<List<ChampionshipGamesViewModel>> GetGamesByChampionship(Guid ChampionshipId);
    }
}
