using System.Threading.Tasks;
using Abp.Application.Services;
using JPY.DISMetroUIPortal.Users.Dto;

namespace JPY.DISMetroUIPortal.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}