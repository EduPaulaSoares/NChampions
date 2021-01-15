using MediatR;
using Microsoft.AspNetCore.Mvc;
using NChampions.Application.Queries;
using NChampions.Domain.Commands.Teams;
using System;
using System.Threading.Tasks;

namespace NChampions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITeamQueries _teamQueries;
        public TeamController(IMediator mediator, ITeamQueries teamQueries)
        {
            _mediator = mediator;
            _teamQueries = teamQueries;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamCommand createTeamCommand)
        {
            var response = await _mediator.Send(createTeamCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTeamCommand updateTeamCommand)
        {
            var response = await _mediator.Send(updateTeamCommand);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _teamQueries.GetAll();
            return Ok(response);
        }
        [HttpGet("{TeamId}")]
        public async Task<IActionResult> GetById(Guid TeamId)
        {
            var response = await _teamQueries.GetById(TeamId);
            return Ok(response);
        }
    }
}
