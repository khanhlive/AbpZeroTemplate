using Abp.Application.Services.Dto;
using System;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class GetAllConstantsForExcelInput
    {
        public string Filter { get; set; }

        public string CodeFilter { get; set; }

        public string NameFilter { get; set; }

        public string DescriptionFilter { get; set; }

        public int? MaxTypeFilter { get; set; }
        public int? MinTypeFilter { get; set; }

    }
}