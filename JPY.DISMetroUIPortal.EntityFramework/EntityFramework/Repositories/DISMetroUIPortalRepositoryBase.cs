using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace JPY.DISMetroUIPortal.EntityFramework.Repositories
{
    public abstract class DISMetroUIPortalRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<DISMetroUIPortalDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected DISMetroUIPortalRepositoryBase(IDbContextProvider<DISMetroUIPortalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class DISMetroUIPortalRepositoryBase<TEntity> : DISMetroUIPortalRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected DISMetroUIPortalRepositoryBase(IDbContextProvider<DISMetroUIPortalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
