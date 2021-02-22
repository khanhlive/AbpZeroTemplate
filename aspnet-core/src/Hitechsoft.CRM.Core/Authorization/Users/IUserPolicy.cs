using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Hitechsoft.CRM.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
