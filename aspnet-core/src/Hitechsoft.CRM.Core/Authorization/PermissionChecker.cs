using Abp.Authorization;
using Hitechsoft.CRM.Authorization.Roles;
using Hitechsoft.CRM.Authorization.Users;

namespace Hitechsoft.CRM.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
