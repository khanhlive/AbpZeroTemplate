using System.Threading.Tasks;
using Hitechsoft.CRM.Security.Recaptcha;

namespace Hitechsoft.CRM.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
