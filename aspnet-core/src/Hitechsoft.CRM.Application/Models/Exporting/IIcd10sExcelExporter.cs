using System.Collections.Generic;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Models.Exporting
{
    public interface IIcd10sExcelExporter
    {
        FileDto ExportToFile(List<GetIcd10ForViewDto> icd10s);
    }
}