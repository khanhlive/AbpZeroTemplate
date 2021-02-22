using Hitechsoft.CRM.Models.Dtos;

using Abp.Extensions;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Gender
{
    public class CreateOrEditGenderModalViewModel
    {
        public CreateOrEditGenderDto Gender { get; set; }

        public bool IsEditMode => Gender.Id.HasValue;
    }
}