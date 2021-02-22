using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}