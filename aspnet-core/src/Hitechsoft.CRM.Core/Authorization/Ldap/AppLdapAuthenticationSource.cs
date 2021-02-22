using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Hitechsoft.CRM.Authorization.Users;
using Hitechsoft.CRM.MultiTenancy;

namespace Hitechsoft.CRM.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}