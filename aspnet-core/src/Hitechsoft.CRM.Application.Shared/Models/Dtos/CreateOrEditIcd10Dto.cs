using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class CreateOrEditIcd10Dto : EntityDto<int?>
    {

        [Required]
        [StringLength(Icd10Consts.MaxCodeLength, MinimumLength = Icd10Consts.MinCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(Icd10Consts.MaxNameLength, MinimumLength = Icd10Consts.MinNameLength)]
        public string Name { get; set; }

        [StringLength(Icd10Consts.MaxDiseaseChapterCodeLength, MinimumLength = Icd10Consts.MinDiseaseChapterCodeLength)]
        public string DiseaseChapterCode { get; set; }

        [StringLength(Icd10Consts.MaxDiseaseChapterNameLength, MinimumLength = Icd10Consts.MinDiseaseChapterNameLength)]
        public string DiseaseChapterName { get; set; }

        [StringLength(Icd10Consts.MaxWHOeNameLength, MinimumLength = Icd10Consts.MinWHOeNameLength)]
        public string WHOeName { get; set; }

        [StringLength(Icd10Consts.MaxWHONameLength, MinimumLength = Icd10Consts.MinWHONameLength)]
        public string WHOName { get; set; }

        public int Status { get; set; }

    }
}