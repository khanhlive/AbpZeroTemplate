using Microsoft.Extensions.Configuration;

namespace Hitechsoft.CRM.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
