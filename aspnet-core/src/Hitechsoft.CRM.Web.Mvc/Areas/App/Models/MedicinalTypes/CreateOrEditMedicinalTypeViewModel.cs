using Hitechsoft.CRM.Models.Dtos;

using Abp.Extensions;

namespace Hitechsoft.CRM.Web.Areas.App.Models.MedicinalTypes
{
    public class CreateOrEditMedicinalTypeModalViewModel
    {
        public CreateOrEditMedicinalTypeDto MedicinalType { get; set; }

        public bool IsEditMode => MedicinalType.Id.HasValue;
    }
}