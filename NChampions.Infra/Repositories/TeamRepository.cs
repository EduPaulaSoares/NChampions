
using Microsoft.EntityFrameworkCore;
using NChampions.Domain.Entities;
using NChampions.Domain.Repositories;
using NChampions.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NChampions.Infra.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly NChampionsContext _ctx;
        public TeamRepository(NChampionsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Team team)
        {
            _ctx.Team.Add(team);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Team>> getTeamsFromIds(List<Guid> ids)
        {
            return  (from Team in _ctx.Team
                         where (ids.Contains(Team.Id))
                         select Team).ToList();
        }

        public async Task<bool> isUniqueTeamName(string teamName)
        {
            return !(await _ctx.Team.Where(x => x.TeamName == teamName).AnyAsync());
        }

        public async Task<bool> isUniqueTeamName(Guid Id, string teamName)
        {
            return !(await _ctx.Team.Where(x => x.Id != Id).AnyAsync(x => x.TeamName.Equals(teamName)));
        }

        public async Task Update(Team team)
        {
            var Team = await _ctx.Team.FindAsync(team.Id);
            Team.UpdateTeam(team);
            await _ctx.SaveChangesAsync();
        }
    }
}
