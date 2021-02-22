using Abp.AutoMapper;
using Hitechsoft.CRM.Authorization.Users;
using Hitechsoft.CRM.Authorization.Users.Dto;
using Hitechsoft.CRM.Web.Areas.App.Models.Common;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}