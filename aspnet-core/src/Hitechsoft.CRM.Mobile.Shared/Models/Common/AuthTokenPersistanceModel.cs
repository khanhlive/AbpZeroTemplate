using System;
using Abp.AutoMapper;
using Hitechsoft.CRM.Sessions.Dto;

namespace Hitechsoft.CRM.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}