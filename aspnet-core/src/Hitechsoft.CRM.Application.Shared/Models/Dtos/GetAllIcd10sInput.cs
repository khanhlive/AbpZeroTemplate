using Abp.Application.Services.Dto;
using System;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class GetAllIcd10sInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string CodeFilter { get; set; }

        public string NameFilter { get; set; }

        public string DiseaseChapterCodeFilter { get; set; }

        public string DiseaseChapterNameFilter { get; set; }

        public string WHOeNameFilter { get; set; }

        public string WHONameFilter { get; set; }

        public int? MaxStatusFilter { get; set; }
        public int? MinStatusFilter { get; set; }

    }
}