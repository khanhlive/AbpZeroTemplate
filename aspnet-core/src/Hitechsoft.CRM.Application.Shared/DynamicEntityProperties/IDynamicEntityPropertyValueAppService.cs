using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.DynamicEntityProperties.Dto;
using Hitechsoft.CRM.DynamicEntityPropertyValues.Dto;

namespace Hitechsoft.CRM.DynamicEntityProperties
{
    public interface IDynamicEntityPropertyValueAppService
    {
        Task<DynamicEntityPropertyValueDto> Get(int id);

        Task<ListResultDto<DynamicEntityPropertyValueDto>> GetAll(GetAllInput input);

        Task Add(DynamicEntityPropertyValueDto input);

        Task Update(DynamicEntityPropertyValueDto input);

        Task Delete(int id);

        Task<GetAllDynamicEntityPropertyValuesOutput> GetAllDynamicEntityPropertyValues(GetAllDynamicEntityPropertyValuesInput input);
    }
}
