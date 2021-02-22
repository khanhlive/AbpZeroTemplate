using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Editions.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}