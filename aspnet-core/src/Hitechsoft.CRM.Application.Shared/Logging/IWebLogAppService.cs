using Abp.Application.Services;
using Hitechsoft.CRM.Dto;
using Hitechsoft.CRM.Logging.Dto;

namespace Hitechsoft.CRM.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
