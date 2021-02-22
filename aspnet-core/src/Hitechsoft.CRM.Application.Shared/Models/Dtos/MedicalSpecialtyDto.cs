using System;
using Abp.Application.Services.Dto;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class MedicalSpecialtyDto : EntityDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Fullname { get; set; }

        public string DecisionCode { get; set; }

        public int Status { get; set; }

    }
}