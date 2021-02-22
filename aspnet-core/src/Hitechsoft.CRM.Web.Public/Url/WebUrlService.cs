using Abp.Dependency;
using Hitechsoft.CRM.Configuration;
using Hitechsoft.CRM.Url;
using Hitechsoft.CRM.Web.Url;

namespace Hitechsoft.CRM.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}