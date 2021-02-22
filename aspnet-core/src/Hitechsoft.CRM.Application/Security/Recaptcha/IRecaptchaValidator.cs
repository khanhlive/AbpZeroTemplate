using System.Threading.Tasks;

namespace Hitechsoft.CRM.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}