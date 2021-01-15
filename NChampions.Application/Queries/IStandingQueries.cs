using NChampions.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChampions.Application.Queries
{
    public interface IStandingQueries
    {
        Task<List<StandingViewModel>> GetChampionshipStanding(Guid ChampionshipID);
    }
}
