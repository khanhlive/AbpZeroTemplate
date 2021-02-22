using Hitechsoft.CRM.Editions;
using Hitechsoft.CRM.Editions.Dto;
using Hitechsoft.CRM.MultiTenancy.Payments;
using Hitechsoft.CRM.Security;
using Hitechsoft.CRM.MultiTenancy.Payments.Dto;

namespace Hitechsoft.CRM.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
