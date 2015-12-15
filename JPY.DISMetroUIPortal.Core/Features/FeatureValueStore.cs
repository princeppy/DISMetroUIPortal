using Abp.Application.Features;
using JPY.DISMetroUIPortal.Authorization.Roles;
using JPY.DISMetroUIPortal.MultiTenancy;
using JPY.DISMetroUIPortal.Users;

namespace JPY.DISMetroUIPortal.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}