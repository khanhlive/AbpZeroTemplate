using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Models
{
    public interface IMedicinalTypesAppService : IApplicationService
    {
        Task<PagedResultDto<GetMedicinalTypeForViewDto>> GetAll(GetAllMedicinalTypesInput input);

        Task<GetMedicinalTypeForViewDto> GetMedicinalTypeForView(int id);

        Task<GetMedicinalTypeForEditOutput> GetMedicinalTypeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditMedicinalTypeDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetMedicinalTypesToExcel(GetAllMedicinalTypesForExcelInput input);

    }
}