using Microsoft.EntityFrameworkCore;

namespace N5Challenge.DataAccess.Repositories
{
    public static class RepositoryExtenssion
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var isVirtual = property.GetGetMethod()?.IsVirtual;
                if (isVirtual == null) continue;
                if (isVirtual.Value)
                {
                    queryable = queryable.Include(property.Name);
                }
            }
            return queryable;
        }
    }
}