using N5Challenge.DataAccess.Interfaces;
using N5Challenge.DataAccess.Repositories;

namespace N5Challenge.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _context;
        private readonly IPermissionRepository _permission;
        private readonly IPermissionTypeRepository _permissionType;

        public UnitOfWork(SqlDbContext context, IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _context = context;
            _permission = permissionRepository;
            _permissionType = permissionTypeRepository;
        }

        public IPermissionRepository PermissionRepository => _permission ?? new PermissionRepository(_context);
        public IPermissionTypeRepository PermissionTypeRepository => _permissionType ?? new PermissionTypeRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}