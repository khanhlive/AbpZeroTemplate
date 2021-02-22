using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Users.Dto;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}