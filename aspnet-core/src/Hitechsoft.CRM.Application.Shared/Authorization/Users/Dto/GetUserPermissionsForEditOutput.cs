using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Permissions.Dto;

namespace Hitechsoft.CRM.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}