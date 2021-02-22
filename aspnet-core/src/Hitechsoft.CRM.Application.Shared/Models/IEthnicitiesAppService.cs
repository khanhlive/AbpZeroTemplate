using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;


namespace Hitechsoft.CRM.Models
{
    public interface IEthnicitiesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetEthnicityForViewDto>> GetAll(GetAllEthnicitiesInput input);

        Task<GetEthnicityForViewDto> GetEthnicityForView(int id);

		Task<GetEthnicityForEditOutput> GetEthnicityForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditEthnicityDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetEthnicitiesToExcel(GetAllEthnicitiesForExcelInput input);

		
    }
}