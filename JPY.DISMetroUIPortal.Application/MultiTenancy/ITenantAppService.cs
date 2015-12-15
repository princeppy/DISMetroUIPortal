using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JPY.DISMetroUIPortal.MultiTenancy.Dto;

namespace JPY.DISMetroUIPortal.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
