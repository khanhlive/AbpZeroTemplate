using System.Threading.Tasks;
using Abp.Webhooks;

namespace Hitechsoft.CRM.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
