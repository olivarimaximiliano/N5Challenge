using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5Challenge.Domain.Commands;
using N5Challenge.Domain.Models;
using N5Challenge.Domain.Queries;

namespace N5Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Permission>> Get()
        {
            return await _mediator.Send(new GetPermissions());
        }

        [HttpGet("{id}")]
        public async Task<Permission> GetPermissionById(int id)
        {
            return await _mediator.Send(new GetPermissionById() { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreatePermission([FromBody] PermissionDto permisionDto)
        {
            await _mediator.Send(new CreatePermission()
            {
                Name = permisionDto.Name,
                Surname = permisionDto.Surname,
                Date = permisionDto.PermissionDate,
                Type = new PermissionType() { Id = permisionDto.PermissionTypeId }
            });

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> ModifyPermission([FromBody] PermissionDto permisionDto)
        {
            await _mediator.Send(new UpdatePermission()
            {
                Id = permisionDto.Id,
                Name = permisionDto.Name,
                Surname = permisionDto.Surname,
                Date = permisionDto.PermissionDate,
                Type = new PermissionType() { Id = permisionDto.PermissionTypeId }
            });

            return Ok();
        }
    }
}