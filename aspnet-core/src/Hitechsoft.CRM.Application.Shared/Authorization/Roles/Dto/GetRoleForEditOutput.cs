using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Permissions.Dto;

namespace Hitechsoft.CRM.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}