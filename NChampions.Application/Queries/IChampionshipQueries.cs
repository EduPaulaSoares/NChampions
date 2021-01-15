using NChampions.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChampions.Application.Queries
{
    public interface IChampionshipQueries
    {
        Task<ChampionshipViewModel> GetById(Guid ChampionshipId);
        Task<List<ChampionshipViewModel>> GetAll();
    }
}
