using Abp.Application.Services.Dto;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}