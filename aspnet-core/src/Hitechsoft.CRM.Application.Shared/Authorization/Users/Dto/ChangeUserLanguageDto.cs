using System.ComponentModel.DataAnnotations;

namespace Hitechsoft.CRM.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
