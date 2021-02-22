using Abp.Auditing;
using Hitechsoft.CRM.Configuration.Dto;

namespace Hitechsoft.CRM.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}