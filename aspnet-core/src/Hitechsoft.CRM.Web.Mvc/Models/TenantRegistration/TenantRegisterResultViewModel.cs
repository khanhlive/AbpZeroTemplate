using Abp.AutoMapper;
using Hitechsoft.CRM.MultiTenancy.Dto;

namespace Hitechsoft.CRM.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}