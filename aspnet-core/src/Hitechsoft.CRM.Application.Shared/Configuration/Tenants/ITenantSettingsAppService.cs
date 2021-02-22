using System.Threading.Tasks;
using Abp.Application.Services;
using Hitechsoft.CRM.Configuration.Tenants.Dto;

namespace Hitechsoft.CRM.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
