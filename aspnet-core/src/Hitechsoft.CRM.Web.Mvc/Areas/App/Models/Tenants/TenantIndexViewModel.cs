using System.Collections.Generic;
using Hitechsoft.CRM.Editions.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}