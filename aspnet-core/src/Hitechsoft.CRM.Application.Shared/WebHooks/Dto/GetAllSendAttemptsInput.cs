using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}
