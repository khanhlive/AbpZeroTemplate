using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Hitechsoft.CRM
{
    [DependsOn(typeof(CRMCoreSharedModule))]
    public class CRMApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMApplicationSharedModule).GetAssembly());
        }
    }
}