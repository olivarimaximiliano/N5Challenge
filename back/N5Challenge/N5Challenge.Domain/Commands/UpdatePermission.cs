using MediatR;
using N5Challenge.Domain.Models;

namespace N5Challenge.Domain.Commands
{
    public class UpdatePermission : IRequest<Permission>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public virtual PermissionType Type { get; set; }
    }
}