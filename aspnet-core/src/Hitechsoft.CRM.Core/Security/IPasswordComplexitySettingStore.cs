using System.Threading.Tasks;

namespace Hitechsoft.CRM.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
