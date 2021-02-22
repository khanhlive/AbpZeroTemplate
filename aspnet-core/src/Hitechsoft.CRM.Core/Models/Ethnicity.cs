using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hitechsoft.CRM.Models
{
    [Table("Ethnicities", Schema = "dic")]
    public class Ethnicity : Entity, IMayHaveTenant, ISoftDelete
    {
        public int? TenantId { get; set; }


        [Required]
        [StringLength(EthnicityConsts.MaxCodeLength, MinimumLength = EthnicityConsts.MinCodeLength)]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(EthnicityConsts.MaxNameLength, MinimumLength = EthnicityConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [StringLength(EthnicityConsts.MaxDescriptionLength, MinimumLength = EthnicityConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual int? Status { get; set; }

        public virtual bool IsDeleted { get; set; }


    }
}