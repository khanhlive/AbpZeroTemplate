using System.Threading.Tasks;
using Abp.Application.Services;
using Hitechsoft.CRM.Configuration.Host.Dto;

namespace Hitechsoft.CRM.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
