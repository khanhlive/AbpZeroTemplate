using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Authorization.Permissions.Dto;

namespace Hitechsoft.CRM.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
