using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class CreateOrEditMedicinalTypeDto : EntityDto<int?>
    {

        [Required]
        [StringLength(MedicinalTypeConsts.MaxCodeLength, MinimumLength = MedicinalTypeConsts.MinCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(MedicinalTypeConsts.MaxNameLength, MinimumLength = MedicinalTypeConsts.MinNameLength)]
        public string Name { get; set; }

        [StringLength(MedicinalTypeConsts.MaxDescriptionLength, MinimumLength = MedicinalTypeConsts.MinDescriptionLength)]
        public string Description { get; set; }

        public int Status { get; set; }

        public bool IsDeleted { get; set; }

    }
}