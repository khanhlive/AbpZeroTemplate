using System.Collections.Generic;
using Abp.Localization;
using Hitechsoft.CRM.Install.Dto;

namespace Hitechsoft.CRM.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
