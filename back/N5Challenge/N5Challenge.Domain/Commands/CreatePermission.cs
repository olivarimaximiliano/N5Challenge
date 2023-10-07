using MediatR;
using N5Challenge.Domain.Models;

namespace N5Challenge.Domain.Commands
{
    public class CreatePermission : IRequest<Permission>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public virtual PermissionType Type { get; set; }
    };
}