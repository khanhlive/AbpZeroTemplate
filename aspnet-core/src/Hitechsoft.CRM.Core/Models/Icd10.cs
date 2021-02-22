using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hitechsoft.CRM.Models
{
    [Table("Icd10s")]
    public class Icd10 : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(Icd10Consts.MaxCodeLength, MinimumLength = Icd10Consts.MinCodeLength)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(Icd10Consts.MaxNameLength, MinimumLength = Icd10Consts.MinNameLength)]
        public virtual string Name { get; set; }

        [StringLength(Icd10Consts.MaxDiseaseChapterCodeLength, MinimumLength = Icd10Consts.MinDiseaseChapterCodeLength)]
        public virtual string DiseaseChapterCode { get; set; }

        [StringLength(Icd10Consts.MaxDiseaseChapterNameLength, MinimumLength = Icd10Consts.MinDiseaseChapterNameLength)]
        public virtual string DiseaseChapterName { get; set; }

        [StringLength(Icd10Consts.MaxWHOeNameLength, MinimumLength = Icd10Consts.MinWHOeNameLength)]
        public virtual string WHOeName { get; set; }

        [StringLength(Icd10Consts.MaxWHONameLength, MinimumLength = Icd10Consts.MinWHONameLength)]
        public virtual string WHOName { get; set; }

        public virtual int Status { get; set; }

    }
}