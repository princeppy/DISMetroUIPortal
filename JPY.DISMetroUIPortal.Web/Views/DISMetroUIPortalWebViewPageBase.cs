using Abp.Web.Mvc.Views;

namespace JPY.DISMetroUIPortal.Web.Views
{
    public abstract class DISMetroUIPortalWebViewPageBase : DISMetroUIPortalWebViewPageBase<dynamic>
    {

    }

    public abstract class DISMetroUIPortalWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected DISMetroUIPortalWebViewPageBase()
        {
            LocalizationSourceName = DISMetroUIPortalConsts.LocalizationSourceName;
        }
    }
}