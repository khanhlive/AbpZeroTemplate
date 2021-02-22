using System;
using Abp.Application.Services.Dto;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class MedicinalTypeDto : EntityDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public bool IsDeleted { get; set; }

    }
}