using System.Globalization;

namespace Hitechsoft.CRM.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}