using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using Hitechsoft.CRM.Configuration;

namespace Hitechsoft.CRM.Test.Base.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(CRMTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
