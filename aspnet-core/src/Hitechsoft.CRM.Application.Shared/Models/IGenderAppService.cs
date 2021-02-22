using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Models
{
    public interface IGenderAppService : IApplicationService
    {
        Task<PagedResultDto<GetGenderForViewDto>> GetAll(GetAllGenderInput input);

        Task<GetGenderForViewDto> GetGenderForView(int id);

        Task<GetGenderForEditOutput> GetGenderForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditGenderDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetGenderToExcel(GetAllGenderForExcelInput input);

    }
}