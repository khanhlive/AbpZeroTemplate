using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Hitechsoft.CRM.Configure;
using Hitechsoft.CRM.Startup;
using Hitechsoft.CRM.Test.Base;

namespace Hitechsoft.CRM.GraphQL.Tests
{
    [DependsOn(
        typeof(CRMGraphQLModule),
        typeof(CRMTestBaseModule))]
    public class CRMGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMGraphQLTestModule).GetAssembly());
        }
    }
}