using System.Threading.Tasks;
using Abp.Application.Services;
using Hitechsoft.CRM.Editions.Dto;
using Hitechsoft.CRM.MultiTenancy.Dto;

namespace Hitechsoft.CRM.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}