using Microsoft.Extensions.Logging;
using NChampions.Domain.Commands.Teams;
using NChampions.Domain.Entities;
using NChampions.Domain.Handlers;
using NChampions.Domain.Repositories;
using NChampions.Domain.Response;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NChampions.Application.Handlers
{
    public class TeamHandler : ITeamHandler
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILogger<TeamHandler> _logger;

        public TeamHandler(ITeamRepository teamRepository, ILoggerFactory ILoggerFactory)
        {
            _teamRepository = teamRepository;
            _logger = ILoggerFactory.CreateLogger<TeamHandler>();

        }

        public async Task<ResponseApi> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create Team : { JsonSerializer.Serialize(request)}");
            try
            {
                var validate = request.Validate(_teamRepository);
                if (!validate.IsValid)
                {   
                    _logger.LogInformation($"ERROR - Create Team : { JsonSerializer.Serialize(validate.Errors.Select(x=> new { Campo = x.PropertyName, Erro = x.ErrorMessage  }).ToList() )}");
                    return new ResponseApi(false, "Erro ao inserir o time", validate.Errors.Select(x => new { Campo = x.PropertyName, Erro = x.ErrorMessage }).ToList());
                }

                Team team = new Team(request.TeamName);
                await _teamRepository.Create(team);
                var response = new { Id = team.Id, TeamName = team.TeamName, isActive = team.IsActive };
                _logger.LogInformation($"SUCCESS - Create Team : { JsonSerializer.Serialize(request)}");
                return new ResponseApi(true, "Time Inserido com Sucesso", response);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"ERROR - Create Team : { JsonSerializer.Serialize(e)}");
                return new ResponseApi(false, "Erro ao inserir o time", e.InnerException.ToString());
            }
        }

        public async Task<ResponseApi> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update Team : { JsonSerializer.Serialize(request)}");
            try
            {  
                var validate = request.Validate(_teamRepository);
                if (!validate.IsValid)
                {   
                    _logger.LogInformation($"ERROR - Update Team : { JsonSerializer.Serialize(validate.Errors.Select(x=> new { Campo = x.PropertyName, Erro = x.ErrorMessage  }).ToList() )}");
                    return new ResponseApi(false, "Erro ao atualizar o time", validate.Errors.Select(x => new { Campo = x.PropertyName, Erro = x.ErrorMessage }).ToList());
                }

                Team team = new Team(request.Id, request.TeamName, request.IsActive);
                await _teamRepository.Update(team);
                var response = new { Id = team.Id, TeamName = team.TeamName, isActive = team.IsActive };

                _logger.LogInformation($"SUCCESS - Update Team: { JsonSerializer.Serialize(response)}");
                return new ResponseApi(true, "Time Atualizado com Sucesso", response);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"ERROR - Update Team : { e.InnerException.ToString() }");
                return new ResponseApi(false, "Erro ao atualizar o time", e.InnerException.ToString());
            }
        }
    }
}
