using MediatR;
using N5Challenge.Domain.Commands;
using N5Challenge.Domain.Models;
using N5Challenge.Services.Interfaces;

namespace N5Challenge.Services.CommandHandlers
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermission, Permission>
    {
        private readonly IPermissionService _service;

        public CreatePermissionHandler(IPermissionService service)
        {
            _service = service;
        }

        public async Task<Permission> Handle(CreatePermission request, CancellationToken cancellationToken)
        {
            return await _service.AddAsync(new Permission()
            {
                Name = request.Name,
                Surname = request.Surname,
                Date = request.Date,
                PermissionType = request.Type,
            });
        }
    }
}
