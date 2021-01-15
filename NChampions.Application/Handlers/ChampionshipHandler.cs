using Microsoft.Extensions.Logging;
using NChampions.Domain.Commands.Championship;
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
    public class ChampionshipHandler : IChampionshipHandler
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ILogger<TeamHandler> _logger;

        public ChampionshipHandler(ITeamRepository teamRepository, IChampionshipRepository championshipRepository, ILoggerFactory ILoggerFactory)
        {
            _teamRepository = teamRepository;
            _championshipRepository = championshipRepository;
            _logger = ILoggerFactory.CreateLogger<TeamHandler>();

        }


        public async Task<ResponseApi> Handle(CreateChampionshipCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create Championship : { JsonSerializer.Serialize(request)}");
            try
            {
                var validate = request.Validate(_championshipRepository,_teamRepository);
                if (!validate.IsValid)
                {
                    _logger.LogInformation($"ERROR - Create Championship : { JsonSerializer.Serialize(validate.Errors.Select(x => new { Campo = x.PropertyName, Erro = x.ErrorMessage }).ToList())}");
                    return new ResponseApi(false, "Erro ao inserir o campeonato", validate.Errors.Select(x => new { Campo = x.PropertyName, Erro = x.ErrorMessage }).ToList());
                }

                Championship championship = new Championship(request.ChampionshipName);
                championship.AddTeams(request.GetTeams());
                await _championshipRepository.Create(championship);

                var response = new { Id = championship.Id, ChampionshipName = championship.ChampionshipName, TeamIds = request.TeamsIds, isActive = championship.IsActive };
                _logger.LogInformation($"SUCCESS - Create Championship : { JsonSerializer.Serialize(response)}");

                return new ResponseApi(true, "Campeonato Inserido com Sucesso",
                    response);

            }
            catch (Exception e)
            {
                _logger.LogInformation($"ERROR - Create Championship : { JsonSerializer.Serialize(e)}");
                return new ResponseApi(false, "Erro ao inserir o campeonato", e.InnerException.ToString());
            }
        }

        public async Task<ResponseApi> Handle(UpdateChampionshipCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update Championship : { JsonSerializer.Serialize(request)}");
            try
            {
                var validate = request.Validate(_championshipRepository, _teamRepository);
                if (!validate.IsValid)
                {
                    _logger.LogInformation($"ERROR - Update Championship : { JsonSerializer.Serialize(validate.Errors.Select(x => new { Campo = x.PropertyName, Erro = x.ErrorMessage }).ToList())}");
                    return new ResponseApi(false, "Erro ao atualizar o campeonato", validate.Errors.Select(x => new { Campo = x.PropertyName, Erro = x.ErrorMessage }).ToList());
                }

                Championship championship = new Championship(request.Id,request.ChampionshipName);
                championship.AddTeams(request.GetTeams());
                await _championshipRepository.Update(championship);

                var response = new { Id = championship.Id, ChampionshipName = championship.ChampionshipName, TeamIds = request.TeamsIds, isActive = championship.IsActive };
                _logger.LogInformation($"SUCCESS - Update Championship : { JsonSerializer.Serialize(response)}");

                return new ResponseApi(true, "Campeonato Atualizado com Sucesso",
                    response);

            }
            catch (Exception e)
            {
                _logger.LogInformation($"ERROR - Create Championship : { JsonSerializer.Serialize(e)}");
                return new ResponseApi(false, "Erro ao inserir o campeonato", e.InnerException.ToString());
            }
        }
    }
}
