using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using JPY.DISMetroUIPortal.Authorization.Roles;
using JPY.DISMetroUIPortal.Editions;
using JPY.DISMetroUIPortal.Users;

namespace JPY.DISMetroUIPortal.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}