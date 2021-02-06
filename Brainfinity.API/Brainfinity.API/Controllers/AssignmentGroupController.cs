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
    public class AssignmentGroupController : ControllerBase
    {

        private readonly IAssignmentGroupService service;

        public AssignmentGroupController(IAssignmentGroupService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentGroup(Guid id) 
        {
            var assignmentGroup = await service.GetEntityById(id);

            return Ok(assignmentGroup);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAssignmentGroup(AssignmentGroupDto assignmentGroup) 
        {
            var insert = await service.InsertEntity(assignmentGroup);

            return Ok(insert);
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignmentGroups(int page, int pageItemCount) 
        {
            var assignmentGroups = await service.GetEntitiesPaginated(page, pageItemCount);

            return Ok(assignmentGroups);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAssignmentGroup(Guid id) 
        {
            await service.RemoveEntity(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignmentGroup(AssignmentGroupDto assignmentGroup, Guid id)
        {
            await service.UpdateEntity(assignmentGroup, id);

            return Ok();
        }

    }
}
