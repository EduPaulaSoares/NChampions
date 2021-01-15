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
    public class ChampionshipRepository : IChampionshipRepository
    {
        private readonly NChampionsContext _ctx;
        public ChampionshipRepository(NChampionsContext ctx)
        {
            _ctx = ctx;
        }

        private List<ChampionshipGame> CreateChampionshipGames(Championship championship)
        {
            List<ChampionshipGame> lstChampionshipGames = new List<ChampionshipGame>();

            foreach (var homeTeam in championship.Teams)
            {
                foreach (var awayTeam in championship.Teams.Where(x => x.Id != homeTeam.Id).ToList())
                {
                    ChampionshipGame championshipGame = new ChampionshipGame(championship, homeTeam, awayTeam);
                    lstChampionshipGames.Add(championshipGame);
                }
            }
            return lstChampionshipGames;
        }

        public async Task Create(Championship championship)
        {
            _ctx.Team.AttachRange(championship.Teams);
            await _ctx.Championship.AddAsync(championship);

            _ctx.ChampionshipGame.AddRange(CreateChampionshipGames(championship));

            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> isUniqueChampionshipName(string championshipName)
        {
            return !(await _ctx.Championship.Where(x => x.ChampionshipName == championshipName).AnyAsync());
        }

        public async Task<bool> isUniqueChampionshipName(Guid id, string championshipName)
        {
            return !(await _ctx.Championship.Where(x => x.Id != id).AnyAsync(x => x.ChampionshipName.Equals(championshipName)));
        }

        public async Task Update(Championship championship)
        {
            var BDChampionship = _ctx.Championship                                            
                                            .Include(x => x.Teams)
                                            .FirstOrDefault(x => x.Id == championship.Id);


            BDChampionship.AddTeams(championship.Teams);
            BDChampionship.UpdateChampionship(championship);            
            await _ctx.SaveChangesAsync();
        }
    }
}
