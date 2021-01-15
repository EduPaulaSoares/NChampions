using NChampions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChampions.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task Create(Team team);
        Task Update(Team team);
        Task<bool> isUniqueTeamName(string teamName);
        Task<bool> isUniqueTeamName(Guid Id, string teamName);
        Task<List<Team>> getTeamsFromIds(List<Guid> ids);
    }
}
