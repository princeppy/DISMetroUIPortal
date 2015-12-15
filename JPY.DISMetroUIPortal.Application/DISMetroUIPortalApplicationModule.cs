using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace JPY.DISMetroUIPortal
{
    [DependsOn(typeof(DISMetroUIPortalCoreModule), typeof(AbpAutoMapperModule))]
    public class DISMetroUIPortalApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
