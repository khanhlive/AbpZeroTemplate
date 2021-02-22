using Abp.AutoMapper;
using Hitechsoft.CRM.Authorization.Roles.Dto;
using Hitechsoft.CRM.Web.Areas.App.Models.Common;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}