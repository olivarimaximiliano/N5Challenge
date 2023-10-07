using N5Challenge.Domain.Models;

namespace N5Challenge.Services.Interfaces
{
    public interface IPermissionService
    {
        public Task<IEnumerable<Permission>> Get();
        public Task<Permission> Get(int id);
        public Task<Permission> AddAsync(Permission permission);
        public Task<Permission> Update(Permission permission);
    }
}