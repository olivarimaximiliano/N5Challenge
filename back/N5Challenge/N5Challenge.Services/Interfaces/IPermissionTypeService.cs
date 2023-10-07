using N5Challenge.Domain.Models;

namespace N5Challenge.Services.Interfaces
{
    public interface IPermissionTypeService
    {
        public Task<IEnumerable<PermissionType>> Get();

        public Task<PermissionType> Get(int id);
    }
}