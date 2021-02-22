using System.Threading.Tasks;
using Abp.Application.Services;

namespace Hitechsoft.CRM.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
