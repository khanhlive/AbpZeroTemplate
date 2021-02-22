using Abp.AutoMapper;
using Hitechsoft.CRM.Localization.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Languages
{
    [AutoMapFrom(typeof(GetLanguageForEditOutput))]
    public class CreateOrEditLanguageModalViewModel : GetLanguageForEditOutput
    {
        public bool IsEditMode => Language.Id.HasValue;
    }
}