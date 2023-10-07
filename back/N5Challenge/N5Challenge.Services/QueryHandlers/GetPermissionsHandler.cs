using MediatR;
using N5Challenge.Domain.Models;
using N5Challenge.Domain.Queries;
using N5Challenge.Services.Interfaces;

namespace N5Challenge.Services.QueryHandlers
{
    public class GetPermissionsHandler : IRequestHandler<GetPermissions, IEnumerable<Permission>>
    {
        private readonly IPermissionService _service;

        public GetPermissionsHandler(IPermissionService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Permission>> Handle(GetPermissions request, CancellationToken cancellationToken)
        {
            return await _service.Get();
        }
    }
}