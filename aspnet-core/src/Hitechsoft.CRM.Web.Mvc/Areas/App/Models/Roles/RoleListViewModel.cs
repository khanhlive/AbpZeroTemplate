using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Authorization.Permissions.Dto;
using Hitechsoft.CRM.Web.Areas.App.Models.Common;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}