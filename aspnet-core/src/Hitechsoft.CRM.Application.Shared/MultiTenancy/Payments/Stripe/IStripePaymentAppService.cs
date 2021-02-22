using System.Threading.Tasks;
using Abp.Application.Services;
using Hitechsoft.CRM.MultiTenancy.Payments.Dto;
using Hitechsoft.CRM.MultiTenancy.Payments.Stripe.Dto;

namespace Hitechsoft.CRM.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}