using N5Challenge.DataAccess.Interfaces;
using N5Challenge.Domain.Models;

namespace N5Challenge.DataAccess.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(SqlDbContext dbContext) : base(dbContext) { }
    }
}