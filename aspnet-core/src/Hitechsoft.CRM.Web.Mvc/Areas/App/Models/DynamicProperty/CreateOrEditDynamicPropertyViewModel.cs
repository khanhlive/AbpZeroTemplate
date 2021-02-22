using System.Collections.Generic;
using Hitechsoft.CRM.DynamicEntityProperties.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
