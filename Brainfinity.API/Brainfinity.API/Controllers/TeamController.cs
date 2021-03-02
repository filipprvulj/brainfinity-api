using Brainfinity.Domain.Pagination;
using Brainfinity.Domain.Resources;
using Brainfinity.Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = RoleNames.Supervizor)]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamsAsync([FromQuery] PaginatorInput paginator)
        {
            return Ok(await teamService.GetTeamsAsync(paginator));
        }

        [HttpPut("{teamId}")]
        public async Task<IActionResult> TeamCompetitionAplly(Guid teamId, Guid competitionId)
        {
            await teamService.TeamCompetitionApply(teamId, competitionId);
            return NoContent();
        }
    }
}