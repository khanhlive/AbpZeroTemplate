using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class CreateOrEditConstantDto : EntityDto<int?>
    {

        [Required]
        [StringLength(ConstantConsts.MaxCodeLength, MinimumLength = ConstantConsts.MinCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(ConstantConsts.MaxNameLength, MinimumLength = ConstantConsts.MinNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(ConstantConsts.MaxDescriptionLength, MinimumLength = ConstantConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public int Type { get; set; }

    }
}