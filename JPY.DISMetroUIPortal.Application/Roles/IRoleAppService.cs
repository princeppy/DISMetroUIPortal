using System.Threading.Tasks;
using Abp.Application.Services;
using JPY.DISMetroUIPortal.Roles.Dto;

namespace JPY.DISMetroUIPortal.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
