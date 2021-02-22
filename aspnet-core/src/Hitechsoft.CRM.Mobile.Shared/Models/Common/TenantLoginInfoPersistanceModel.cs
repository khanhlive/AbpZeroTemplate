using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Hitechsoft.CRM.Sessions.Dto;

namespace Hitechsoft.CRM.Models.Common
{
    [AutoMapFrom(typeof(TenantLoginInfoDto)),
     AutoMapTo(typeof(TenantLoginInfoDto))]
    public class TenantLoginInfoPersistanceModel : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}