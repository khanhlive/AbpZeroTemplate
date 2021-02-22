using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hitechsoft.CRM.Models
{
    [Table("Constants")]
    public class Constant : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(ConstantConsts.MaxCodeLength, MinimumLength = ConstantConsts.MinCodeLength)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(ConstantConsts.MaxNameLength, MinimumLength = ConstantConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(ConstantConsts.MaxDescriptionLength, MinimumLength = ConstantConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int Type { get; set; }

    }
}