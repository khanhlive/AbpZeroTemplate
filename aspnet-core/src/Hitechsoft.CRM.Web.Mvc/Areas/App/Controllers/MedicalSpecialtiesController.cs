using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hitechsoft.CRM.Web.Areas.App.Models.MedicalSpecialties;
using Hitechsoft.CRM.Web.Controllers;
using Hitechsoft.CRM.Authorization;
using Hitechsoft.CRM.Models;
using Hitechsoft.CRM.Models.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace Hitechsoft.CRM.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_MedicalSpecialties)]
    public class MedicalSpecialtiesController : CRMControllerBase
    {
        private readonly IMedicalSpecialtiesAppService _medicalSpecialtiesAppService;

        public MedicalSpecialtiesController(IMedicalSpecialtiesAppService medicalSpecialtiesAppService)
        {
            _medicalSpecialtiesAppService = medicalSpecialtiesAppService;
        }

        public ActionResult Index()
        {
            var model = new MedicalSpecialtiesViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_MedicalSpecialties_Create, AppPermissions.Pages_MedicalSpecialties_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetMedicalSpecialtyForEditOutput getMedicalSpecialtyForEditOutput;

            if (id.HasValue)
            {
                getMedicalSpecialtyForEditOutput = await _medicalSpecialtiesAppService.GetMedicalSpecialtyForEdit(new EntityDto { Id = (int)id });
            }
            else
            {
                getMedicalSpecialtyForEditOutput = new GetMedicalSpecialtyForEditOutput
                {
                    MedicalSpecialty = new CreateOrEditMedicalSpecialtyDto()
                };
            }

            var viewModel = new CreateOrEditMedicalSpecialtyModalViewModel()
            {
                MedicalSpecialty = getMedicalSpecialtyForEditOutput.MedicalSpecialty,
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewMedicalSpecialtyModal(int id)
        {
            var getMedicalSpecialtyForViewDto = await _medicalSpecialtiesAppService.GetMedicalSpecialtyForView(id);

            var model = new MedicalSpecialtyViewModel()
            {
                MedicalSpecialty = getMedicalSpecialtyForViewDto.MedicalSpecialty
            };

            return PartialView("_ViewMedicalSpecialtyModal", model);
        }

    }
}