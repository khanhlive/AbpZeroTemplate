using Hitechsoft.CRM.Models.Dtos;

using Abp.Extensions;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Constants
{
    public class CreateOrEditConstantModalViewModel
    {
        public CreateOrEditConstantDto Constant { get; set; }

        public bool IsEditMode => Constant.Id.HasValue;
    }
}