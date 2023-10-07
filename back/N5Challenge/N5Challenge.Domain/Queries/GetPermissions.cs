using MediatR;
using N5Challenge.Domain.Models;

namespace N5Challenge.Domain.Queries
{
    public class GetPermissions : IRequest<IEnumerable<Permission>>
    {
    }
}