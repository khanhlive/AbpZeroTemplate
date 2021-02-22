using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Users.Dto;

namespace Hitechsoft.CRM.Web.Areas.App.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}