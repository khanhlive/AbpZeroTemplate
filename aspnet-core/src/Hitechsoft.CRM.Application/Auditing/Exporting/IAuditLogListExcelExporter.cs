using System.Collections.Generic;
using Hitechsoft.CRM.Auditing.Dto;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
