﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hitechsoft.CRM.Web.Areas.App.Models.Layout;
using Hitechsoft.CRM.Web.Session;
using Hitechsoft.CRM.Web.Views;

namespace Hitechsoft.CRM.Web.Areas.App.Views.Shared.Themes.Theme7.Components.AppTheme7Footer
{
    public class AppTheme7FooterViewComponent : CRMViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme7FooterViewComponent(IPerRequestSessionCache sessionCache)
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
