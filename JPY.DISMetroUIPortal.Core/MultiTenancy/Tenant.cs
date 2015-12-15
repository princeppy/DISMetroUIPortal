using Abp.MultiTenancy;
using JPY.DISMetroUIPortal.Users;

namespace JPY.DISMetroUIPortal.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}