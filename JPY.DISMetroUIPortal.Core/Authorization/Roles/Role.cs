using Abp.Authorization.Roles;
using JPY.DISMetroUIPortal.MultiTenancy;
using JPY.DISMetroUIPortal.Users;

namespace JPY.DISMetroUIPortal.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}