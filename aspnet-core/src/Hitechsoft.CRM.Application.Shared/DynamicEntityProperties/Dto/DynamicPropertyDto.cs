using Abp.Application.Services.Dto;

namespace Hitechsoft.CRM.DynamicEntityProperties.Dto
{
    public class DynamicPropertyDto : EntityDto
    {
        public string PropertyName { get; set; }

        public string InputType { get; set; }

        public string Permission { get; set; }

        public int? TenantId { get; set; }
    }
}
