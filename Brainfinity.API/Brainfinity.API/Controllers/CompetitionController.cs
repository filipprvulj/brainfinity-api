using Brainfinity.Domain.Dtos;
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
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService service;

        public CompetitionController(ICompetitionService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetition(Guid id)
        {
            var competition = await service.GetEntityById(id);

            return Ok(competition);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCompetition(CompetitionDto competition)
        {
            var insert = await service.InsertEntity(competition);

            return Ok(insert);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompetitions(int page, int pageItemCount)
        {
            var competitions = await service.GetEntitiesPaginated(page, pageItemCount);

            return Ok(competitions);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCompetition(Guid id)
        {
            await service.RemoveEntity(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetition(CompetitionDto competition, Guid id)
        {
            await service.UpdateEntity(competition, id);
            return Ok();
        }
    }
}