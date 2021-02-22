using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Users.Importing.Dto;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
