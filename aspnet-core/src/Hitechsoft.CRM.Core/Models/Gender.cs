using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hitechsoft.CRM.Models
{
    [Table("Gender")]
    public class Gender : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(GenderConsts.MaxCodeLength, MinimumLength = GenderConsts.MinCodeLength)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(GenderConsts.MaxNameLength, MinimumLength = GenderConsts.MinNameLength)]
        public virtual string Name { get; set; }

        public virtual bool IsDeleted { get; set; }

    }
}