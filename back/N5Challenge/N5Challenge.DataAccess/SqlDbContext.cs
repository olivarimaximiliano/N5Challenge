using Microsoft.EntityFrameworkCore;
using N5Challenge.Domain.Models;

namespace N5Challenge.DataAccess
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionType> Type { get; set; }
    }
}