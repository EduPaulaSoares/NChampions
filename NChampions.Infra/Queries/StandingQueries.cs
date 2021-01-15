using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NChampions.Application.Queries;
using NChampions.Application.ViewModels;
using NChampions.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChampions.Infra.Queries
{
    public class StandingQueries : IStandingQueries
    {
        private readonly NChampionsContext context;
        private readonly SqlConnection _sqlConnection;

        public StandingQueries(NChampionsContext context)
        {
            _sqlConnection = new SqlConnection(context.Database.GetConnectionString());
            this.context = context;
        }

        public async Task<List<StandingViewModel>> GetChampionshipStanding(Guid ChampionshipID)
        {
            var queryArgs = new DynamicParameters();
            queryArgs.Add("Id", ChampionshipID);

            var query = @"Select 	
	                        TeamName,
	                        (Wins * 3) + Draws as Points,
	                        Wins,
	                        Draws,
	                        Loses	
                        FROM ( Select 
			                        t.TeamName as TeamName,
			                        (select count(1) from ChampionshipGame cg where cg.HomeTeamId = t.Id and cg.HomeScore>cg.AwayScore) + (select count(1) from ChampionshipGame cg where cg.AwayTeamId = t.Id and cg.AwayScore>cg.HomeScore) as Wins ,
			                        (select count(1) from ChampionshipGame cg where cg.HomeTeamId = t.Id and cg.HomeScore=cg.AwayScore) + (select count(1) from ChampionshipGame cg where cg.AwayTeamId = t.Id and cg.AwayScore=cg.HomeScore) as Draws,
			                        (select count(1) from ChampionshipGame cg where cg.HomeTeamId = t.Id and cg.HomeScore<cg.AwayScore) + (select count(1) from ChampionshipGame cg where cg.AwayTeamId = t.Id and cg.AwayScore<cg.HomeScore) as Loses
		                        from Team t
			                        inner join ChampionshipTeam ct on t.Id=ct.TeamsId
		                        where 
			                        ct.ChampionshipsId = @Id
		                        ) Query
	                        order by Points desc, Wins desc
                        ";


            var result = (await _sqlConnection.QueryAsync<StandingViewModel>(query, queryArgs)).AsList<StandingViewModel>();

            
            return result;
        }
    }
}
