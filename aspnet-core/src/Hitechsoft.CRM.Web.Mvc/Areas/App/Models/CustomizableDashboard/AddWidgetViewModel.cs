using System.Collections.Generic;
using Hitechsoft.CRM.DashboardCustomization.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
