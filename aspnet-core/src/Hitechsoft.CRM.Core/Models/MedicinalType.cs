using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hitechsoft.CRM.Models
{
    [Table("MedicinalTypes", Schema = "dic")]
    public class MedicinalType : Entity, IMayHaveTenant, ISoftDelete
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(MedicinalTypeConsts.MaxCodeLength, MinimumLength = MedicinalTypeConsts.MinCodeLength)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(MedicinalTypeConsts.MaxNameLength, MinimumLength = MedicinalTypeConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [StringLength(MedicinalTypeConsts.MaxDescriptionLength, MinimumLength = MedicinalTypeConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Status { get; set; }

        public virtual bool IsDeleted { get; set; }

    }
}