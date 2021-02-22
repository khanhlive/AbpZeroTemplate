using System.Collections.Generic;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Models.Exporting
{
    public interface IEthnicitiesExcelExporter
    {
        FileDto ExportToFile(List<GetEthnicityForViewDto> ethnicities);
    }
}