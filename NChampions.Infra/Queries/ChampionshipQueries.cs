using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NChampions.Application.Queries;
using NChampions.Application.ViewModels;
using NChampions.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NChampions.Infra.Queries
{
    public class ChampionshipQueries : IChampionshipQueries
    {
        private readonly NChampionsContext context;
        private readonly SqlConnection _sqlConnection;

        public ChampionshipQueries(NChampionsContext context)
        {
            _sqlConnection = new SqlConnection(context.Database.GetConnectionString());
            this.context = context;
        }

        public async Task<List<ChampionshipViewModel>> GetAll()
        {

            var query = @"select 
                          c.Id,
                    	  c.ChampionshipName,
	                      c.isActive,
	                      t.id as ChampionshipTeams_Id,
	                      t.TeamName as ChampionshipTeams_TeamName,
	                      t.IsActive as ChampionshipTeams_isActive
                      from Championship c
                        inner join ChampionshipTeam ct on c.id = ct.ChampionshipsId
                        inner join Team t on ct.TeamsId = t.Id
                      order by t.TeamName";


            var result = await _sqlConnection.QueryAsync<dynamic>(query);

            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ChampionshipViewModel), "Id");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(List<TeamViewModel>), "Id");

            List<ChampionshipViewModel> lst = Slapper.AutoMapper.MapDynamic<ChampionshipViewModel>(result).ToList();

            return lst;

        }

        public async Task<ChampionshipViewModel> GetById(Guid ChampionshipId)
        {
            var queryArgs = new DynamicParameters();
            queryArgs.Add("Id", ChampionshipId);

            var query = @"select 
                          c.Id,
                    	  c.ChampionshipName,
	                      c.isActive,
	                      t.id as ChampionshipTeams_Id,
	                      t.TeamName as ChampionshipTeams_TeamName,
	                      t.IsActive as ChampionshipTeams_isActive
                      from Championship c
                        inner join ChampionshipTeam ct on c.id = ct.ChampionshipsId
                        inner join Team t on ct.TeamsId = t.Id
                      Where c.Id = @Id
                      order by t.TeamName";

            var result = await _sqlConnection.QueryAsync<dynamic>(query, queryArgs);

            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ChampionshipViewModel), "Id");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(List<TeamViewModel>), "Id");

            ChampionshipViewModel obj = Slapper.AutoMapper.MapDynamic<ChampionshipViewModel>(result).FirstOrDefault();


            return obj;
        }
    }
}
