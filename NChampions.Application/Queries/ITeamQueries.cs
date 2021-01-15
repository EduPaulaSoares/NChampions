using NChampions.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChampions.Application.Queries
{
    public interface ITeamQueries
    {
        Task<TeamViewModel> GetById(Guid TeamId);
        Task<List<TeamViewModel>> GetAll();
    }
}
