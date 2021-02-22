using System.Collections.Generic;
using MvvmHelpers;
using Hitechsoft.CRM.Models.NavigationMenu;

namespace Hitechsoft.CRM.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}