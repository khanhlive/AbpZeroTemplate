using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Permissions.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}