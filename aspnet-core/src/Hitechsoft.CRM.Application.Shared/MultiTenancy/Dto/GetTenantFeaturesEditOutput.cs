using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Editions.Dto;

namespace Hitechsoft.CRM.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}