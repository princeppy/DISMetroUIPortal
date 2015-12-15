using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JPY.DISMetroUIPortal.MultiTenancy;

namespace JPY.DISMetroUIPortal.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}