using System.Collections.Generic;
using Hitechsoft.CRM.Caching.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}