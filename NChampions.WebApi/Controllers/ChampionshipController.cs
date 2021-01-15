using MediatR;
using Microsoft.AspNetCore.Mvc;
using NChampions.Application.Queries;
using NChampions.Domain.Commands.Championship;
using System;
using System.Threading.Tasks;

namespace NChampions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IChampionshipQueries _championshipQueries;

        public ChampionshipController(IMediator mediator, IChampionshipQueries championshipQueries)
        {
            _mediator = mediator;
            _championshipQueries = championshipQueries;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateChampionshipCommand createChampionshipCommand)
        {
            var response = await _mediator.Send(createChampionshipCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateChampionshipCommand updateChampionshipCommand)
        {
            var response = await _mediator.Send(updateChampionshipCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _championshipQueries.GetAll();
            return Ok(response);
        }

        [HttpGet("{ChampionshipId}")]
        public async Task<IActionResult> GetById(Guid ChampionshipId)
        {
            var response = await _championshipQueries.GetById(ChampionshipId);
            return Ok(response);
        }
    }
}
