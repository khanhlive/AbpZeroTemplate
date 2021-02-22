
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class CreateOrEditEthnicityDto : EntityDto<int?>
    {

		[Required]
		[StringLength(EthnicityConsts.MaxCodeLength, MinimumLength = EthnicityConsts.MinCodeLength)]
		public string Code { get; set; }
		
		
		[Required]
		[StringLength(EthnicityConsts.MaxNameLength, MinimumLength = EthnicityConsts.MinNameLength)]
		public string Name { get; set; }
		
		
		[StringLength(EthnicityConsts.MaxDescriptionLength, MinimumLength = EthnicityConsts.MinDescriptionLength)]
		public string Description { get; set; }
		
		
		public int? Status { get; set; }
		
		
		public bool IsDeleted { get; set; }
		
		

    }
}