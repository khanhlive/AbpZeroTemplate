using Abp.Application.Services.Dto;
using System;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class GetAllGenderInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}