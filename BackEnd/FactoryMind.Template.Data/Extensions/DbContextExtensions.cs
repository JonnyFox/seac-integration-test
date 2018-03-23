using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FactoryMind.Template.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FactoryMind.Template.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> FindBy<T>(this DbContext source, Specification<T> spec, bool trackChanges = true)
            where T : class, IEntity
        {
            var dbSet = source.Set<T>();
            var result = dbSet.Where(spec);

            if (!trackChanges)
            {
                result = result.AsNoTracking();
            }

            return result;
        }

        public static Task<List<T>> FindManyAsync<T>(this DbContext source, Specification<T> spec, bool trackChanges = true, CancellationToken ct = default(CancellationToken))
            where T : class, IEntity
        {
            return source.FindBy(spec, trackChanges).ToListAsync(ct);
        }

        public static Task<T> FindSingleAsync<T>(this DbContext source, Specification<T> spec, bool trackChanges = true, CancellationToken ct = default(CancellationToken))
            where T : class, IEntity
        {
            return source.FindBy(spec, trackChanges).SingleAsync(ct);
        }

        public static Task<T> FindSingleOrDefaultAsync<T>(this DbContext source, Specification<T> spec, bool trackChanges = true, CancellationToken ct = default(CancellationToken))
            where T : class, IEntity
        {
            return source.FindBy(spec, trackChanges).SingleOrDefaultAsync(ct);
        }

        public static Task<T> FindFirstAsync<T>(this DbContext source, Specification<T> spec, bool trackChanges = true, CancellationToken ct = default(CancellationToken))
            where T : class, IEntity
        {
            return source.FindBy(spec, trackChanges).FirstAsync(ct);
        }

        public static Task<T> FindFirstOrDefaultAsync<T>(this DbContext source, Specification<T> spec, bool trackChanges = true, CancellationToken ct = default(CancellationToken))
            where T : class, IEntity
        {
            return source.FindBy(spec, trackChanges).FirstOrDefaultAsync(ct);
        }
    }
}