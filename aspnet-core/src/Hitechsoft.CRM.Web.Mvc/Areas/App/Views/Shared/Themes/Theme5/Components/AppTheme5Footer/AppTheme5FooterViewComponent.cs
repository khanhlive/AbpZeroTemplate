﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hitechsoft.CRM.Web.Areas.App.Models.Layout;
using Hitechsoft.CRM.Web.Session;
using Hitechsoft.CRM.Web.Views;

namespace Hitechsoft.CRM.Web.Areas.App.Views.Shared.Themes.Theme5.Components.AppTheme5Footer
{
    public class AppTheme5FooterViewComponent : CRMViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme5FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
