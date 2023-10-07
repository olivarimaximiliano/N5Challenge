using MediatR;
using N5Challenge.Domain.Commands;
using N5Challenge.Domain.Models;
using N5Challenge.Services.Interfaces;

namespace N5Challenge.Services.CommandHandlers
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermission, Permission>
    {
        private readonly IPermissionService _service;
        private readonly IPermissionTypeService _serviceType;

        public UpdatePermissionHandler(IPermissionService service, IPermissionTypeService serviceType)
        {
            _service = service;
            _serviceType = serviceType;
        }

        public async Task<Permission> Handle(UpdatePermission request, CancellationToken cancellationToken)
        {
            var type = await _serviceType.Get(request.Type.Id);
            return await _service.Update(new Permission()
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Date = request.Date,
                PermissionType = type,
            });
        }
    }
}