using System.Collections.Generic;
using Hitechsoft.CRM.Editions.Dto;
using Hitechsoft.CRM.MultiTenancy.Payments;

namespace Hitechsoft.CRM.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}