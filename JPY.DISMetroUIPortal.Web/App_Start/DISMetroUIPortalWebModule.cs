using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Zero.Configuration;
using JPY.DISMetroUIPortal.Api;

namespace JPY.DISMetroUIPortal.Web
{
    [DependsOn(
        typeof(DISMetroUIPortalDataModule), 
        typeof(DISMetroUIPortalApplicationModule), 
        typeof(DISMetroUIPortalWebApiModule),
        typeof(AbpWebMvcModule))]
    public class DISMetroUIPortalWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<DISMetroUIPortalNavigationProvider>();

            IocManager.Register<Abp.Runtime.Session.IAbpSession, DISMetroUIPortalWindowsAbpSession>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
