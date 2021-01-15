using MediatR;
using Microsoft.AspNetCore.Mvc;
using NChampions.Application.Queries;
using NChampions.Domain.Commands.ChampionshipGame;
using System;
using System.Threading.Tasks;

namespace NChampions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipGameController : ControllerBase
    {
        private readonly IChampionshipGameQueries _championshipGamesQueries;
        private readonly IMediator _mediator;
        public ChampionshipGameController(IChampionshipGameQueries championshipGamesQueries,IMediator mediator)
        {
            _championshipGamesQueries = championshipGamesQueries;
            _mediator = mediator;
        }

        [HttpGet("Championship/{championshipId}")]
        public async Task<IActionResult> GetById(Guid championshipId)
        {
            var response = await _championshipGamesQueries.GetGamesByChampionship(championshipId);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateChampionshipGameCommand updateChampionshipGameCommand)
        {
            var response = await _mediator.Send(updateChampionshipGameCommand);
            return Ok(response);
        }
    }
}
