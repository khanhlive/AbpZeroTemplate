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
    [AbpAuthorize(AppPermissions.Pages_Constants)]
    public class ConstantsAppService : CRMAppServiceBase, IConstantsAppService
    {
        private readonly IRepository<Constant> _constantRepository;
        private readonly IConstantsExcelExporter _constantsExcelExporter;

        public ConstantsAppService(IRepository<Constant> constantRepository, IConstantsExcelExporter constantsExcelExporter)
        {
            _constantRepository = constantRepository;
            _constantsExcelExporter = constantsExcelExporter;

        }

        public async Task<PagedResultDto<GetConstantForViewDto>> GetAll(GetAllConstantsInput input)
        {

            var filteredConstants = _constantRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter), e => e.Code == input.CodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(input.MinTypeFilter != null, e => e.Type >= input.MinTypeFilter)
                        .WhereIf(input.MaxTypeFilter != null, e => e.Type <= input.MaxTypeFilter);

            var pagedAndFilteredConstants = filteredConstants
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var constants = from o in pagedAndFilteredConstants
                            select new GetConstantForViewDto()
                            {
                                Constant = new ConstantDto
                                {
                                    Code = o.Code,
                                    Name = o.Name,
                                    Description = o.Description,
                                    Type = o.Type,
                                    Id = o.Id
                                }
                            };

            var totalCount = await filteredConstants.CountAsync();

            return new PagedResultDto<GetConstantForViewDto>(
                totalCount,
                await constants.ToListAsync()
            );
        }

        public async Task<GetConstantForViewDto> GetConstantForView(int id)
        {
            var constant = await _constantRepository.GetAsync(id);

            var output = new GetConstantForViewDto { Constant = ObjectMapper.Map<ConstantDto>(constant) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Constants_Edit)]
        public async Task<GetConstantForEditOutput> GetConstantForEdit(EntityDto input)
        {
            var constant = await _constantRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetConstantForEditOutput { Constant = ObjectMapper.Map<CreateOrEditConstantDto>(constant) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditConstantDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Constants_Create)]
        protected virtual async Task Create(CreateOrEditConstantDto input)
        {
            var constant = ObjectMapper.Map<Constant>(input);

            if (AbpSession.TenantId != null)
            {
                constant.TenantId = (int?)AbpSession.TenantId;
            }

            await _constantRepository.InsertAsync(constant);
        }

        [AbpAuthorize(AppPermissions.Pages_Constants_Edit)]
        protected virtual async Task Update(CreateOrEditConstantDto input)
        {
            var constant = await _constantRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, constant);
        }

        [AbpAuthorize(AppPermissions.Pages_Constants_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _constantRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetConstantsToExcel(GetAllConstantsForExcelInput input)
        {

            var filteredConstants = _constantRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Code.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CodeFilter), e => e.Code == input.CodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(input.MinTypeFilter != null, e => e.Type >= input.MinTypeFilter)
                        .WhereIf(input.MaxTypeFilter != null, e => e.Type <= input.MaxTypeFilter);

            var query = (from o in filteredConstants
                         select new GetConstantForViewDto()
                         {
                             Constant = new ConstantDto
                             {
                                 Code = o.Code,
                                 Name = o.Name,
                                 Description = o.Description,
                                 Type = o.Type,
                                 Id = o.Id
                             }
                         });

            var constantListDtos = await query.ToListAsync();

            return _constantsExcelExporter.ExportToFile(constantListDtos);
        }

    }
}