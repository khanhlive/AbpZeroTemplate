using System.Threading.Tasks;
using Hitechsoft.CRM.Authorization.Users;

namespace Hitechsoft.CRM.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
