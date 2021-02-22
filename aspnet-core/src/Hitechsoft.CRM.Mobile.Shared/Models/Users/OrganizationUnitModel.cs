using Abp.AutoMapper;
using Hitechsoft.CRM.Organizations.Dto;

namespace Hitechsoft.CRM.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}