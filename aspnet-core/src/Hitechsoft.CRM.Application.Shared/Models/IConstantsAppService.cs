using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Models
{
    public interface IConstantsAppService : IApplicationService
    {
        Task<PagedResultDto<GetConstantForViewDto>> GetAll(GetAllConstantsInput input);

        Task<GetConstantForViewDto> GetConstantForView(int id);

        Task<GetConstantForEditOutput> GetConstantForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditConstantDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetConstantsToExcel(GetAllConstantsForExcelInput input);

    }
}