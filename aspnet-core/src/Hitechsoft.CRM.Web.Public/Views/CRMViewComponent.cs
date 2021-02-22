using Abp.AspNetCore.Mvc.ViewComponents;

namespace Hitechsoft.CRM.Web.Public.Views
{
    public abstract class CRMViewComponent : AbpViewComponent
    {
        protected CRMViewComponent()
        {
            LocalizationSourceName = CRMConsts.LocalizationSourceName;
        }
    }
}