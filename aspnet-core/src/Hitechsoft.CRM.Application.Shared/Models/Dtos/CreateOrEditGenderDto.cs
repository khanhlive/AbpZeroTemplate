using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class CreateOrEditGenderDto : EntityDto<int?>
    {

        [Required]
        [StringLength(GenderConsts.MaxCodeLength, MinimumLength = GenderConsts.MinCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(GenderConsts.MaxNameLength, MinimumLength = GenderConsts.MinNameLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

    }
}