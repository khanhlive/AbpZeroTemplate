using System.Threading.Tasks;
using Hitechsoft.CRM.Sessions.Dto;

namespace Hitechsoft.CRM.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
