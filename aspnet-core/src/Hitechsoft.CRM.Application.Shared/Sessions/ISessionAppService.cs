using System.Threading.Tasks;
using Abp.Application.Services;
using Hitechsoft.CRM.Sessions.Dto;

namespace Hitechsoft.CRM.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
