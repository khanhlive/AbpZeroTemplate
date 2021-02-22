using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hitechsoft.CRM.Models
{
    [Table("MedicalSpecialties")]
    public class MedicalSpecialty : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(MedicalSpecialtyConsts.MaxCodeLength, MinimumLength = MedicalSpecialtyConsts.MinCodeLength)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(MedicalSpecialtyConsts.MaxNameLength, MinimumLength = MedicalSpecialtyConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [StringLength(MedicalSpecialtyConsts.MaxFullnameLength, MinimumLength = MedicalSpecialtyConsts.MinFullnameLength)]
        public virtual string Fullname { get; set; }

        [StringLength(MedicalSpecialtyConsts.MaxDecisionCodeLength, MinimumLength = MedicalSpecialtyConsts.MinDecisionCodeLength)]
        public virtual string DecisionCode { get; set; }

        public virtual int Status { get; set; }

    }
}