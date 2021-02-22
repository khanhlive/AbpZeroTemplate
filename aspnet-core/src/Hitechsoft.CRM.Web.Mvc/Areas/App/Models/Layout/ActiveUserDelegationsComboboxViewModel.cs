using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Delegation;
using Hitechsoft.CRM.Authorization.Users.Delegation.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
