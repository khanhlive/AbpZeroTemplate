using Hitechsoft.CRM.MultiTenancy.Payments;

namespace Hitechsoft.CRM.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}