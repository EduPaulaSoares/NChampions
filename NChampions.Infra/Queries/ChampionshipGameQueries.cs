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
    public class ChampionshipGameQueries : IChampionshipGameQueries
    {
		private readonly NChampionsContext context;
		private readonly SqlConnection _sqlConnection;

		public ChampionshipGameQueries(NChampionsContext context)
		{
			_sqlConnection = new SqlConnection(context.Database.GetConnectionString());
			this.context = context;
		}

		public async Task<List<ChampionshipGamesViewModel>> GetGamesByChampionship(Guid ChampionshipId)
        {
            var queryArgs = new DynamicParameters();
            queryArgs.Add("IdChampionship", ChampionshipId);

            var query = @"Select 
							game.Id as IdChampionshipGame,
							c.Id as IdChampionship,
							c.ChampionshipName,
							homeT.TeamName as HomeTeam,
							homeT.Id as IdHomeTeam ,
							game.HomeScore,
							awayT.TeamName as AwayTeam,
							awayT.Id as IdAwayTeam,
							game.AwayScore,
							game.GameDate,
							game.IsActive
							from ChampionshipGame game
								inner join Championship c ON game.ChampionshipId = c.Id
								inner join Team homeT ON game.HomeTeamId = homeT.Id
								inner join Team awayT ON game.AwayTeamId = awayT.Id
							Where c.Id=@IdChampionship";


			var result = (await _sqlConnection.QueryAsync<ChampionshipGamesViewModel>(query, queryArgs)).AsList<ChampionshipGamesViewModel>();
			return result;
		}
    }
}
