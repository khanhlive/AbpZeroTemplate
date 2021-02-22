using System;
using Abp.Application.Services.Dto;

namespace Hitechsoft.CRM.Models.Dtos
{
    public class Icd10Dto : EntityDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string DiseaseChapterCode { get; set; }

        public string DiseaseChapterName { get; set; }

        public string WHOeName { get; set; }

        public string WHOName { get; set; }

        public int Status { get; set; }

    }
}