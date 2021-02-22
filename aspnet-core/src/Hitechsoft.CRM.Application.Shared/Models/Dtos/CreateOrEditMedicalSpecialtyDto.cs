using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class CreateOrEditMedicalSpecialtyDto : EntityDto<int?>
    {

        [Required]
        [StringLength(MedicalSpecialtyConsts.MaxCodeLength, MinimumLength = MedicalSpecialtyConsts.MinCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(MedicalSpecialtyConsts.MaxNameLength, MinimumLength = MedicalSpecialtyConsts.MinNameLength)]
        public string Name { get; set; }

        [StringLength(MedicalSpecialtyConsts.MaxFullnameLength, MinimumLength = MedicalSpecialtyConsts.MinFullnameLength)]
        public string Fullname { get; set; }

        [StringLength(MedicalSpecialtyConsts.MaxDecisionCodeLength, MinimumLength = MedicalSpecialtyConsts.MinDecisionCodeLength)]
        public string DecisionCode { get; set; }

        public int Status { get; set; }

    }
}