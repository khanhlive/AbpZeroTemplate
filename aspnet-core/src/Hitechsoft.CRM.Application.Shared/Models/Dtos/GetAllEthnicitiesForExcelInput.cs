using Abp.Application.Services.Dto;
using System;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class GetAllEthnicitiesForExcelInput
    {
		public string Filter { get; set; }

		public string CodeFilter { get; set; }

		public string NameFilter { get; set; }

		public string DescriptionFilter { get; set; }

		public int? MaxStatusFilter { get; set; }
		public int? MinStatusFilter { get; set; }

		public int IsDeletedFilter { get; set; }



    }
}