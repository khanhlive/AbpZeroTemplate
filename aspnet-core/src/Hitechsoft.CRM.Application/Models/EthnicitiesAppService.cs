

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Hitechsoft.CRM.Models.Exporting;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Hitechsoft.CRM.Models
{
	[AbpAuthorize(AppPermissions.Pages_Administration_Ethnicities)]
    public class EthnicitiesAppService : CRMAppServiceBase, IEthnicitiesAppService
    {
		 private readonly IRepository<Ethnicity> _ethnicityRepository;
		 private readonly IEthnicitiesExcelExporter _ethnicitiesExcelExporter;
		 

		  public EthnicitiesAppService(IRepository<Ethnicity> ethnicityRepository, IEthnicitiesExcelExporter ethnicitiesExcelExporter ) 
		  {
			_ethnicityRepository = ethnicityRepository;
			_ethnicitiesExcelExporter = ethnicitiesExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetEthnicityForViewDto>> GetAll(GetAllEthnicitiesInput input)
         {
			
			var filteredEthnicities = _ethnicityRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter),  e => e.Code == input.CodeFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),  e => e.Description == input.DescriptionFilter)
						.WhereIf(input.MinStatusFilter != null, e => e.Status >= input.MinStatusFilter)
						.WhereIf(input.MaxStatusFilter != null, e => e.Status <= input.MaxStatusFilter)
						.WhereIf(input.IsDeletedFilter > -1,  e => (input.IsDeletedFilter == 1 && e.IsDeleted) || (input.IsDeletedFilter == 0 && !e.IsDeleted) );

			var pagedAndFilteredEthnicities = filteredEthnicities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var ethnicities = from o in pagedAndFilteredEthnicities
                         select new GetEthnicityForViewDto() {
							Ethnicity = new EthnicityDto
							{
                                Code = o.Code,
                                Name = o.Name,
                                Description = o.Description,
                                Status = o.Status,
                                IsDeleted = o.IsDeleted,
                                Id = o.Id
							}
						};

            var totalCount = await filteredEthnicities.CountAsync();

            return new PagedResultDto<GetEthnicityForViewDto>(
                totalCount,
                await ethnicities.ToListAsync()
            );
         }
		 
		 public async Task<GetEthnicityForViewDto> GetEthnicityForView(int id)
         {
            var ethnicity = await _ethnicityRepository.GetAsync(id);

            var output = new GetEthnicityForViewDto { Ethnicity = ObjectMapper.Map<EthnicityDto>(ethnicity) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Administration_Ethnicities_Edit)]
		 public async Task<GetEthnicityForEditOutput> GetEthnicityForEdit(EntityDto input)
         {
            var ethnicity = await _ethnicityRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetEthnicityForEditOutput {Ethnicity = ObjectMapper.Map<CreateOrEditEthnicityDto>(ethnicity)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditEthnicityDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Ethnicities_Create)]
		 protected virtual async Task Create(CreateOrEditEthnicityDto input)
         {
            var ethnicity = ObjectMapper.Map<Ethnicity>(input);

			
			if (AbpSession.TenantId != null)
			{
				ethnicity.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _ethnicityRepository.InsertAsync(ethnicity);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Ethnicities_Edit)]
		 protected virtual async Task Update(CreateOrEditEthnicityDto input)
         {
            var ethnicity = await _ethnicityRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, ethnicity);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Ethnicities_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _ethnicityRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetEthnicitiesToExcel(GetAllEthnicitiesForExcelInput input)
         {
			
			var filteredEthnicities = _ethnicityRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter),  e => e.Code == input.CodeFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),  e => e.Description == input.DescriptionFilter)
						.WhereIf(input.MinStatusFilter != null, e => e.Status >= input.MinStatusFilter)
						.WhereIf(input.MaxStatusFilter != null, e => e.Status <= input.MaxStatusFilter)
						.WhereIf(input.IsDeletedFilter > -1,  e => (input.IsDeletedFilter == 1 && e.IsDeleted) || (input.IsDeletedFilter == 0 && !e.IsDeleted) );

			var query = (from o in filteredEthnicities
                         select new GetEthnicityForViewDto() { 
							Ethnicity = new EthnicityDto
							{
                                Code = o.Code,
                                Name = o.Name,
                                Description = o.Description,
                                Status = o.Status,
                                IsDeleted = o.IsDeleted,
                                Id = o.Id
							}
						 });


            var ethnicityListDtos = await query.ToListAsync();

            return _ethnicitiesExcelExporter.ExportToFile(ethnicityListDtos);
         }


    }
}