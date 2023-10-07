using MediatR;
using N5Challenge.Domain.Models;

namespace N5Challenge.Domain.Queries
{
    public class GetPermissionById : IRequest<Permission>
    {
        public int Id { get; set; }
    }
}