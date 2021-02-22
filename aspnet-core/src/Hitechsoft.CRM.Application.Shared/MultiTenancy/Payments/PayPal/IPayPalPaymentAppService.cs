using System.Threading.Tasks;
using Abp.Application.Services;
using Hitechsoft.CRM.MultiTenancy.Payments.PayPal.Dto;

namespace Hitechsoft.CRM.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
