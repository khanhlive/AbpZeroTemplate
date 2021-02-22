using System.Collections.Generic;
using Hitechsoft.CRM.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Hitechsoft.CRM.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
