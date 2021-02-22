using System.Collections.Generic;
using Hitechsoft.CRM.Editions;
using Hitechsoft.CRM.Editions.Dto;
using Hitechsoft.CRM.MultiTenancy.Payments;
using Hitechsoft.CRM.MultiTenancy.Payments.Dto;

namespace Hitechsoft.CRM.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
