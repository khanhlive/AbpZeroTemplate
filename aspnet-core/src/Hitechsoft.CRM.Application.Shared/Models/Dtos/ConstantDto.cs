using System;
using Abp.Application.Services.Dto;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class ConstantDto : EntityDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

    }
}