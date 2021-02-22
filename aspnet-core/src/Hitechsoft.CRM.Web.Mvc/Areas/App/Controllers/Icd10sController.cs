using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hitechsoft.CRM.Web.Areas.App.Models.Icd10s;
using Hitechsoft.CRM.Web.Controllers;
using Hitechsoft.CRM.Authorization;
using Hitechsoft.CRM.Models;
using Hitechsoft.CRM.Models.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace Hitechsoft.CRM.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Icd10s)]
    public class Icd10sController : CRMControllerBase
    {
        private readonly IIcd10sAppService _icd10sAppService;

        public Icd10sController(IIcd10sAppService icd10sAppService)
        {
            _icd10sAppService = icd10sAppService;
        }

        public ActionResult Index()
        {
            var model = new Icd10sViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Icd10s_Create, AppPermissions.Pages_Icd10s_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetIcd10ForEditOutput getIcd10ForEditOutput;

            if (id.HasValue)
            {
                getIcd10ForEditOutput = await _icd10sAppService.GetIcd10ForEdit(new EntityDto { Id = (int)id });
            }
            else
            {
                getIcd10ForEditOutput = new GetIcd10ForEditOutput
                {
                    Icd10 = new CreateOrEditIcd10Dto()
                };
            }

            var viewModel = new CreateOrEditIcd10ModalViewModel()
            {
                Icd10 = getIcd10ForEditOutput.Icd10,
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewIcd10Modal(int id)
        {
            var getIcd10ForViewDto = await _icd10sAppService.GetIcd10ForView(id);

            var model = new Icd10ViewModel()
            {
                Icd10 = getIcd10ForViewDto.Icd10
            };

            return PartialView("_ViewIcd10Modal", model);
        }

    }
}