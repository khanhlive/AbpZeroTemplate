using Hitechsoft.CRM.Models.Dtos;

using Abp.Extensions;

namespace Hitechsoft.CRM.Web.Areas.App.Models.MedicalSpecialties
{
    public class CreateOrEditMedicalSpecialtyModalViewModel
    {
        public CreateOrEditMedicalSpecialtyDto MedicalSpecialty { get; set; }

        public bool IsEditMode => MedicalSpecialty.Id.HasValue;
    }
}