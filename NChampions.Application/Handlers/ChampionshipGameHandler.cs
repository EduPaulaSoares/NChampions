using Microsoft.Extensions.Logging;
using NChampions.Domain.Commands.ChampionshipGame;
using NChampions.Domain.Entities;
using NChampions.Domain.Handlers;
using NChampions.Domain.Repositories;
using NChampions.Domain.Response;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NChampions.Application.Handlers
{
    public class ChampionshipGameHandler : IChampionshipGameHandler
    {
        private readonly IChampionshipGameRepository _championshipGameRepository;
        
        private readonly ILogger<ChampionshipHandler> _logger;

        public ChampionshipGameHandler(IChampionshipGameRepository championshipGameRepository, ILoggerFactory ILoggerFactory)
        {
            _championshipGameRepository = championshipGameRepository;
            

            _logger = ILoggerFactory.CreateLogger<ChampionshipHandler>();
        }

        public async Task<ResponseApi> Handle(UpdateChampionshipGameCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update Championship Game : { JsonSerializer.Serialize(request)}");
            try
            {
                ChampionshipGame championshipGame = new ChampionshipGame(request.Id, request.HomeScore, request.AwayScore, request.GameDate);
                await _championshipGameRepository.Update(championshipGame);


                var response = new { Id = championshipGame.Id, HomeScore = championshipGame.HomeScore , AwayScore = championshipGame.AwayScore, GameDate = championshipGame.GameDate };
                _logger.LogInformation($"SUCCESS - Update Championship Game : { JsonSerializer.Serialize(response)}");

                return new ResponseApi(true, "Jogo Atualizado com Sucesso",
                    response);


            }
            catch (Exception e)
            {
                _logger.LogInformation($"ERROR - Update Championship Game : { JsonSerializer.Serialize(e)}");
                return new ResponseApi(false, "Erro ao atualizar o jogo", e.InnerException.ToString());
            }
        }
    }
}
