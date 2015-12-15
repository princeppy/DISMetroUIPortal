using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using JPY.DISMetroUIPortal.EntityFramework;

namespace JPY.DISMetroUIPortal
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(DISMetroUIPortalCoreModule))]
    public class DISMetroUIPortalDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
