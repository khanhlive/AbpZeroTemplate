using Abp.Application.Services.Dto;
using System;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class GetAllMedicinalTypesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}