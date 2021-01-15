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
    public class TeamQueries : ITeamQueries
    {
        private readonly NChampionsContext context;
        private readonly SqlConnection _sqlConnection;

        public TeamQueries(NChampionsContext context)
        {
            _sqlConnection = new SqlConnection(context.Database.GetConnectionString());
            this.context = context;
        }

        public async Task<List<TeamViewModel>> GetAll()
        {
            var result = (await _sqlConnection.QueryAsync<TeamViewModel>("Select Id, TeamName, isActive From Team")).AsList<TeamViewModel>();
            return result;
        }

        public async Task<TeamViewModel> GetById(Guid TeamId)
        {
            var queryArgs = new DynamicParameters();
            queryArgs.Add("Id", TeamId);

            var result = (await _sqlConnection.QueryAsync<TeamViewModel>("Select Id, TeamName, isActive From Team where Id = @id", queryArgs)).FirstOrDefault();
            return result;
        }
    }
}
