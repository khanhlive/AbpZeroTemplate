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
    [AbpAuthorize(AppPermissions.Pages_Administration_MedicinalTypes)]
    public class MedicinalTypesAppService : CRMAppServiceBase, IMedicinalTypesAppService
    {
        private readonly IRepository<MedicinalType> _medicinalTypeRepository;
        private readonly IMedicinalTypesExcelExporter _medicinalTypesExcelExporter;

        public MedicinalTypesAppService(IRepository<MedicinalType> medicinalTypeRepository, IMedicinalTypesExcelExporter medicinalTypesExcelExporter)
        {
            _medicinalTypeRepository = medicinalTypeRepository;
            _medicinalTypesExcelExporter = medicinalTypesExcelExporter;

        }

        public async Task<PagedResultDto<GetMedicinalTypeForViewDto>> GetAll(GetAllMedicinalTypesInput input)
        {

            var filteredMedicinalTypes = _medicinalTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter));

            var pagedAndFilteredMedicinalTypes = filteredMedicinalTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var medicinalTypes = from o in pagedAndFilteredMedicinalTypes
                                 select new GetMedicinalTypeForViewDto()
                                 {
                                     MedicinalType = new MedicinalTypeDto
                                     {
                                         Code = o.Code,
                                         Name = o.Name,
                                         Description = o.Description,
                                         Status = o.Status,
                                         IsDeleted = o.IsDeleted,
                                         Id = o.Id
                                     }
                                 };

            var totalCount = await filteredMedicinalTypes.CountAsync();

            return new PagedResultDto<GetMedicinalTypeForViewDto>(
                totalCount,
                await medicinalTypes.ToListAsync()
            );
        }

        public async Task<GetMedicinalTypeForViewDto> GetMedicinalTypeForView(int id)
        {
            var medicinalType = await _medicinalTypeRepository.GetAsync(id);

            var output = new GetMedicinalTypeForViewDto { MedicinalType = ObjectMapper.Map<MedicinalTypeDto>(medicinalType) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_MedicinalTypes_Edit)]
        public async Task<GetMedicinalTypeForEditOutput> GetMedicinalTypeForEdit(EntityDto input)
        {
            var medicinalType = await _medicinalTypeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetMedicinalTypeForEditOutput { MedicinalType = ObjectMapper.Map<CreateOrEditMedicinalTypeDto>(medicinalType) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditMedicinalTypeDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_MedicinalTypes_Create)]
        protected virtual async Task Create(CreateOrEditMedicinalTypeDto input)
        {
            var medicinalType = ObjectMapper.Map<MedicinalType>(input);

            if (AbpSession.TenantId != null)
            {
                medicinalType.TenantId = (int?)AbpSession.TenantId;
            }

            await _medicinalTypeRepository.InsertAsync(medicinalType);
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_MedicinalTypes_Edit)]
        protected virtual async Task Update(CreateOrEditMedicinalTypeDto input)
        {
            var medicinalType = await _medicinalTypeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, medicinalType);
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_MedicinalTypes_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _medicinalTypeRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetMedicinalTypesToExcel(GetAllMedicinalTypesForExcelInput input)
        {

            var filteredMedicinalTypes = _medicinalTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter));

            var query = (from o in filteredMedicinalTypes
                         select new GetMedicinalTypeForViewDto()
                         {
                             MedicinalType = new MedicinalTypeDto
                             {
                                 Code = o.Code,
                                 Name = o.Name,
                                 Description = o.Description,
                                 Status = o.Status,
                                 IsDeleted = o.IsDeleted,
                                 Id = o.Id
                             }
                         });

            var medicinalTypeListDtos = await query.ToListAsync();

            return _medicinalTypesExcelExporter.ExportToFile(medicinalTypeListDtos);
        }

    }
}