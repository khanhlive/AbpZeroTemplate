using Abp.AutoMapper;
using Hitechsoft.CRM.MultiTenancy.Dto;

namespace Hitechsoft.CRM.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
