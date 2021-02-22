using Hitechsoft.CRM.Models.Dtos;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Gender
{
    public class GenderViewModel : GetGenderForViewDto
    {
        public string FilterText { get; set; }
    }
}