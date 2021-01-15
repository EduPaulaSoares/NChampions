using Microsoft.AspNetCore.Mvc;
using NChampions.Application.Queries;
using System;
using System.Threading.Tasks;

namespace NChampions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingController : ControllerBase
    {
        private readonly IStandingQueries _standingQueries;
        public StandingController(IStandingQueries standingQueries)
        {
            _standingQueries = standingQueries;
        }

        [HttpGet("Championship/{championshipId}")]
        public async Task<IActionResult> GetChampionshipStanding(Guid championshipId)
        {
            var response = await _standingQueries.GetChampionshipStanding(championshipId);
            return Ok(response);
        }
    }
}
