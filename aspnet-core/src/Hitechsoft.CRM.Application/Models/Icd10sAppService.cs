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
    [AbpAuthorize(AppPermissions.Pages_Icd10s)]
    public class Icd10sAppService : CRMAppServiceBase, IIcd10sAppService
    {
        private readonly IRepository<Icd10> _icd10Repository;
        private readonly IIcd10sExcelExporter _icd10sExcelExporter;

        public Icd10sAppService(IRepository<Icd10> icd10Repository, IIcd10sExcelExporter icd10sExcelExporter)
        {
            _icd10Repository = icd10Repository;
            _icd10sExcelExporter = icd10sExcelExporter;

        }

        public async Task<PagedResultDto<GetIcd10ForViewDto>> GetAll(GetAllIcd10sInput input)
        {

            var filteredIcd10s = _icd10Repository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.DiseaseChapterCode.Contains(input.Filter) || e.DiseaseChapterName.Contains(input.Filter) || e.WHOeName.Contains(input.Filter) || e.WHOName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter), e => e.Code == input.CodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiseaseChapterCodeFilter), e => e.DiseaseChapterCode == input.DiseaseChapterCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiseaseChapterNameFilter), e => e.DiseaseChapterName == input.DiseaseChapterNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WHOeNameFilter), e => e.WHOeName == input.WHOeNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WHONameFilter), e => e.WHOName == input.WHONameFilter)
                        .WhereIf(input.MinStatusFilter != null, e => e.Status >= input.MinStatusFilter)
                        .WhereIf(input.MaxStatusFilter != null, e => e.Status <= input.MaxStatusFilter);

            var pagedAndFilteredIcd10s = filteredIcd10s
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var icd10s = from o in pagedAndFilteredIcd10s
                         select new GetIcd10ForViewDto()
                         {
                             Icd10 = new Icd10Dto
                             {
                                 Code = o.Code,
                                 Name = o.Name,
                                 DiseaseChapterCode = o.DiseaseChapterCode,
                                 DiseaseChapterName = o.DiseaseChapterName,
                                 WHOeName = o.WHOeName,
                                 WHOName = o.WHOName,
                                 Status = o.Status,
                                 Id = o.Id
                             }
                         };

            var totalCount = await filteredIcd10s.CountAsync();

            return new PagedResultDto<GetIcd10ForViewDto>(
                totalCount,
                await icd10s.ToListAsync()
            );
        }

        public async Task<GetIcd10ForViewDto> GetIcd10ForView(int id)
        {
            var icd10 = await _icd10Repository.GetAsync(id);

            var output = new GetIcd10ForViewDto { Icd10 = ObjectMapper.Map<Icd10Dto>(icd10) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Icd10s_Edit)]
        public async Task<GetIcd10ForEditOutput> GetIcd10ForEdit(EntityDto input)
        {
            var icd10 = await _icd10Repository.FirstOrDefaultAsync(input.Id);

            var output = new GetIcd10ForEditOutput { Icd10 = ObjectMapper.Map<CreateOrEditIcd10Dto>(icd10) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditIcd10Dto input)
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

        [AbpAuthorize(AppPermissions.Pages_Icd10s_Create)]
        protected virtual async Task Create(CreateOrEditIcd10Dto input)
        {
            var icd10 = ObjectMapper.Map<Icd10>(input);

            if (AbpSession.TenantId != null)
            {
                icd10.TenantId = (int?)AbpSession.TenantId;
            }

            await _icd10Repository.InsertAsync(icd10);
        }

        [AbpAuthorize(AppPermissions.Pages_Icd10s_Edit)]
        protected virtual async Task Update(CreateOrEditIcd10Dto input)
        {
            var icd10 = await _icd10Repository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, icd10);
        }

        [AbpAuthorize(AppPermissions.Pages_Icd10s_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _icd10Repository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetIcd10sToExcel(GetAllIcd10sForExcelInput input)
        {

            var filteredIcd10s = _icd10Repository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.DiseaseChapterCode.Contains(input.Filter) || e.DiseaseChapterName.Contains(input.Filter) || e.WHOeName.Contains(input.Filter) || e.WHOName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter), e => e.Code == input.CodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiseaseChapterCodeFilter), e => e.DiseaseChapterCode == input.DiseaseChapterCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiseaseChapterNameFilter), e => e.DiseaseChapterName == input.DiseaseChapterNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WHOeNameFilter), e => e.WHOeName == input.WHOeNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WHONameFilter), e => e.WHOName == input.WHONameFilter)
                        .WhereIf(input.MinStatusFilter != null, e => e.Status >= input.MinStatusFilter)
                        .WhereIf(input.MaxStatusFilter != null, e => e.Status <= input.MaxStatusFilter);

            var query = (from o in filteredIcd10s
                         select new GetIcd10ForViewDto()
                         {
                             Icd10 = new Icd10Dto
                             {
                                 Code = o.Code,
                                 Name = o.Name,
                                 DiseaseChapterCode = o.DiseaseChapterCode,
                                 DiseaseChapterName = o.DiseaseChapterName,
                                 WHOeName = o.WHOeName,
                                 WHOName = o.WHOName,
                                 Status = o.Status,
                                 Id = o.Id
                             }
                         });

            var icd10ListDtos = await query.ToListAsync();

            return _icd10sExcelExporter.ExportToFile(icd10ListDtos);
        }

    }
}