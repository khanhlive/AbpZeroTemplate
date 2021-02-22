using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Hitechsoft.CRM.Authorization;

namespace Hitechsoft.CRM
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(CRMApplicationSharedModule),
        typeof(CRMCoreModule)
        )]
    public class CRMApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMApplicationModule).GetAssembly());
        }
    }
}