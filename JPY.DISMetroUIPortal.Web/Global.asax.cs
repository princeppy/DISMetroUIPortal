using System;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;
// For Mixed Auth
using MohammadYounes.Owin.Security.MixedAuth;
namespace JPY.DISMetroUIPortal.Web
{
    public class MvcApplication : AbpWebApplication
    {
        public MvcApplication()
        {
            //register MixedAuth
            this.RegisterMixedAuth();
        }

        protected override void Application_Start(object sender, EventArgs e)
        {
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
