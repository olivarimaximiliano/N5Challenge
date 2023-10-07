namespace N5Challenge.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IPermissionRepository PermissionRepository { get; }
        IPermissionTypeRepository PermissionTypeRepository { get; }
        Task SaveAsync();
    }
}