using N5Challenge.DataAccess.Interfaces;
using N5Challenge.Domain.Models;

namespace N5Challenge.DataAccess.Repositories
{
    public class PermissionTypeRepository : Repository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(SqlDbContext dbContext) : base(dbContext) { }
    }
}