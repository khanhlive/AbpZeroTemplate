using Hitechsoft.CRM.Models.Dtos;

using Abp.Extensions;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Ethnicities
{
    public class CreateOrEditEthnicityModalViewModel
    {
       public CreateOrEditEthnicityDto Ethnicity { get; set; }

	   
       
	   public bool IsEditMode => Ethnicity.Id.HasValue;
    }
}