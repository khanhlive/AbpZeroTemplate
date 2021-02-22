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
    [AbpAuthorize(AppPermissions.Pages_MedicalSpecialties)]
    public class MedicalSpecialtiesAppService : CRMAppServiceBase, IMedicalSpecialtiesAppService
    {
        private readonly IRepository<MedicalSpecialty> _medicalSpecialtyRepository;
        private readonly IMedicalSpecialtiesExcelExporter _medicalSpecialtiesExcelExporter;

        public MedicalSpecialtiesAppService(IRepository<MedicalSpecialty> medicalSpecialtyRepository, IMedicalSpecialtiesExcelExporter medicalSpecialtiesExcelExporter)
        {
            _medicalSpecialtyRepository = medicalSpecialtyRepository;
            _medicalSpecialtiesExcelExporter = medicalSpecialtiesExcelExporter;

        }

        public async Task<PagedResultDto<GetMedicalSpecialtyForViewDto>> GetAll(GetAllMedicalSpecialtiesInput input)
        {

            var filteredMedicalSpecialties = _medicalSpecialtyRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Fullname.Contains(input.Filter) || e.DecisionCode.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter), e => e.Code == input.CodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FullnameFilter), e => e.Fullname == input.FullnameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DecisionCodeFilter), e => e.DecisionCode == input.DecisionCodeFilter)
                        .WhereIf(input.MinStatusFilter != null, e => e.Status >= input.MinStatusFilter)
                        .WhereIf(input.MaxStatusFilter != null, e => e.Status <= input.MaxStatusFilter);

            var pagedAndFilteredMedicalSpecialties = filteredMedicalSpecialties
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var medicalSpecialties = from o in pagedAndFilteredMedicalSpecialties
                                     select new GetMedicalSpecialtyForViewDto()
                                     {
                                         MedicalSpecialty = new MedicalSpecialtyDto
                                         {
                                             Code = o.Code,
                                             Name = o.Name,
                                             Fullname = o.Fullname,
                                             DecisionCode = o.DecisionCode,
                                             Status = o.Status,
                                             Id = o.Id
                                         }
                                     };

            var totalCount = await filteredMedicalSpecialties.CountAsync();

            return new PagedResultDto<GetMedicalSpecialtyForViewDto>(
                totalCount,
                await medicalSpecialties.ToListAsync()
            );
        }

        public async Task<GetMedicalSpecialtyForViewDto> GetMedicalSpecialtyForView(int id)
        {
            var medicalSpecialty = await _medicalSpecialtyRepository.GetAsync(id);

            var output = new GetMedicalSpecialtyForViewDto { MedicalSpecialty = ObjectMapper.Map<MedicalSpecialtyDto>(medicalSpecialty) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_MedicalSpecialties_Edit)]
        public async Task<GetMedicalSpecialtyForEditOutput> GetMedicalSpecialtyForEdit(EntityDto input)
        {
            var medicalSpecialty = await _medicalSpecialtyRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetMedicalSpecialtyForEditOutput { MedicalSpecialty = ObjectMapper.Map<CreateOrEditMedicalSpecialtyDto>(medicalSpecialty) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditMedicalSpecialtyDto input)
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

        [AbpAuthorize(AppPermissions.Pages_MedicalSpecialties_Create)]
        protected virtual async Task Create(CreateOrEditMedicalSpecialtyDto input)
        {
            var medicalSpecialty = ObjectMapper.Map<MedicalSpecialty>(input);

            if (AbpSession.TenantId != null)
            {
                medicalSpecialty.TenantId = (int?)AbpSession.TenantId;
            }

            await _medicalSpecialtyRepository.InsertAsync(medicalSpecialty);
        }

        [AbpAuthorize(AppPermissions.Pages_MedicalSpecialties_Edit)]
        protected virtual async Task Update(CreateOrEditMedicalSpecialtyDto input)
        {
            var medicalSpecialty = await _medicalSpecialtyRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, medicalSpecialty);
        }

        [AbpAuthorize(AppPermissions.Pages_MedicalSpecialties_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _medicalSpecialtyRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetMedicalSpecialtiesToExcel(GetAllMedicalSpecialtiesForExcelInput input)
        {

            var filteredMedicalSpecialties = _medicalSpecialtyRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Fullname.Contains(input.Filter) || e.DecisionCode.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter), e => e.Code == input.CodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FullnameFilter), e => e.Fullname == input.FullnameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DecisionCodeFilter), e => e.DecisionCode == input.DecisionCodeFilter)
                        .WhereIf(input.MinStatusFilter != null, e => e.Status >= input.MinStatusFilter)
                        .WhereIf(input.MaxStatusFilter != null, e => e.Status <= input.MaxStatusFilter);

            var query = (from o in filteredMedicalSpecialties
                         select new GetMedicalSpecialtyForViewDto()
                         {
                             MedicalSpecialty = new MedicalSpecialtyDto
                             {
                                 Code = o.Code,
                                 Name = o.Name,
                                 Fullname = o.Fullname,
                                 DecisionCode = o.DecisionCode,
                                 Status = o.Status,
                                 Id = o.Id
                             }
                         });

            var medicalSpecialtyListDtos = await query.ToListAsync();

            return _medicalSpecialtiesExcelExporter.ExportToFile(medicalSpecialtyListDtos);
        }

    }
}