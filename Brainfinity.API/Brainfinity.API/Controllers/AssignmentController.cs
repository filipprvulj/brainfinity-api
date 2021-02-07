using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.ServiceInterfaces;
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
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService service;

        public AssignmentController(IAssignmentService service) 
        {
            this.service = service;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment(Guid id)
        {
            var assignment = await service.GetEntityById(id);

            return Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAssignment(AssignmentDto assignment)
        {
            var insert = await service.InsertEntity(assignment);

            return Ok(insert);
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignments(int page, int pageItemCount)
        {
            var assignment = await service.GetEntitiesPaginated(page, pageItemCount);

            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAssignment(Guid id)
        {
            await service.RemoveEntity(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(AssignmentDto assignment, Guid id)
        {
            await service.UpdateEntity(assignment, id);

            return Ok();
        }
    }
}
