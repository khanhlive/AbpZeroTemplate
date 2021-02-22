using Hitechsoft.CRM.Editions.Dto;

namespace Hitechsoft.CRM.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < CRMConsts.MinimumUpgradePaymentAmount;
        }
    }
}
