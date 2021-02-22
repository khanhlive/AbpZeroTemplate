using System.Collections.Generic;

namespace Hitechsoft.CRM.MultiTenancy.Payments
{
    public interface IPaymentGatewayStore
    {
        List<PaymentGatewayModel> GetActiveGateways();
    }
}
