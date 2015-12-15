using Abp.Authorization;
using JPY.DISMetroUIPortal.Authorization.Roles;
using JPY.DISMetroUIPortal.MultiTenancy;
using JPY.DISMetroUIPortal.Users;

namespace JPY.DISMetroUIPortal.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
