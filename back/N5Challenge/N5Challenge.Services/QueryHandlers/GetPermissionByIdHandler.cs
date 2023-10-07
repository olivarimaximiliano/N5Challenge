using MediatR;
using N5Challenge.Domain.Models;
using N5Challenge.Domain.Queries;
using N5Challenge.Services.Interfaces;

namespace N5Challenge.Services.QueryHandlers
{
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionById, Permission>
    {
        private readonly IPermissionService _service;

        public GetPermissionByIdHandler(IPermissionService service)
        {
            _service = service;
        }

        public async Task<Permission> Handle(GetPermissionById request, CancellationToken cancellationToken)
        {
            return await _service.Get(request.Id);
        }
    }
}