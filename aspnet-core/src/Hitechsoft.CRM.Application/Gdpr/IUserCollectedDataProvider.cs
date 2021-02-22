using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
