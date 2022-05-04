using Microsoft.EntityFrameworkCore;
using MovieSiteProject.Core.Entities.Abstract;
using MovieSiteProject.Core.Utilities.IoC;
using MovieSiteProject.Repository.Concrete.EntityFramework;
using System.Linq.Expressions;

namespace MovieSiteProject.Core.Repository.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                addedEntity.State = EntityState.Detached;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

                deletedEntity.State = EntityState.Detached;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                return context.Set<TEntity>().AsNoTrackingWithIdentityResolution().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                return filter == null ? context.Set<TEntity>().AsNoTracking().ToList() : context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = ServiceTool.ServiceProvider.GetService<ProjectDbContext>())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

                updatedEntity.State = EntityState.Detached;
                context.SaveChanges();
            }
        }
    }
}
