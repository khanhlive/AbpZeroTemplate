using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Hitechsoft.CRM.Startup
{
    [DependsOn(typeof(CRMCoreModule))]
    public class CRMGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}