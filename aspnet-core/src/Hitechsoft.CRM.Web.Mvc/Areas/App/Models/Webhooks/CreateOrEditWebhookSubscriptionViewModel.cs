using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Hitechsoft.CRM.WebHooks.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
