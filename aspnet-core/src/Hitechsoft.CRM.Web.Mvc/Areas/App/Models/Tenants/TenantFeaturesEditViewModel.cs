using Abp.AutoMapper;
using Hitechsoft.CRM.MultiTenancy;
using Hitechsoft.CRM.MultiTenancy.Dto;
using Hitechsoft.CRM.Web.Areas.App.Models.Common;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}