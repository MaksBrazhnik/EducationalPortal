using EducationalPortal.DAL.DBOperation;
using EducationalPortal.Domain.Entities;
using EducationalPortal.Domain.Interfaces.RepositoriesEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EducationalPortal.DAL.RepositoryEFImplementation
{
    public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
    {
        private readonly EducationalPortalContext educationalPortalContext;

        public GenericRepository(EducationalPortalContext educationalPortalContext)
        {
            this.educationalPortalContext = educationalPortalContext;
        }

        public async Task<int> CreateAsync(T entity)
        {
            var entityEntry = await educationalPortalContext.Set<T>().AddAsync(entity);
            await educationalPortalContext.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            educationalPortalContext.Set<T>().Remove(entity);
            await educationalPortalContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            educationalPortalContext.Set<T>().RemoveRange(entities);

            await educationalPortalContext.SaveChangesAsync();
        }

        public IQueryable<T> Find(bool disableTracking = true,
            Expression<Func<T, bool>> predicateExpression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = educationalPortalContext.Set<T>().AsQueryable();

            if (disableTracking)
            {
                query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicateExpression != null)
            {
                query = query.Where(predicateExpression);
            }

            return query;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicateExpression = null,
            bool disableTracking = true)
        {
            var query = educationalPortalContext.Set<T>();

            if (disableTracking)
            {
                query.AsNoTracking();
            }

            return await query.Where(predicateExpression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            var query = educationalPortalContext.Set<T>().AsQueryable();

            if (disableTracking)
            {
                query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            educationalPortalContext.Set<T>().Update(entity);
            await educationalPortalContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            educationalPortalContext.Set<T>().UpdateRange(entities);
            await educationalPortalContext.SaveChangesAsync();
        }
    }
}
