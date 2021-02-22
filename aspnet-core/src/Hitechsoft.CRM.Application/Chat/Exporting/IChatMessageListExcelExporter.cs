using System.Collections.Generic;
using Abp;
using Hitechsoft.CRM.Chat.Dto;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
