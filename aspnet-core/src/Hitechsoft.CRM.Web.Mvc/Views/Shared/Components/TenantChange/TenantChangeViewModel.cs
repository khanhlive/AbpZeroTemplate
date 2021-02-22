using Abp.AutoMapper;
using Hitechsoft.CRM.Sessions.Dto;

namespace Hitechsoft.CRM.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}