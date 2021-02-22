using System.Threading.Tasks;
using Abp.Application.Services;
using Hitechsoft.CRM.Install.Dto;

namespace Hitechsoft.CRM.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}