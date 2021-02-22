using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hitechsoft.CRM.DataExporting.Excel.NPOI;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;
using Hitechsoft.CRM.Storage;

namespace Hitechsoft.CRM.Models.Exporting
{
    public class GenderExcelExporter : NpoiExcelExporterBase, IGenderExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public GenderExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetGenderForViewDto> gender)
        {
            return CreateExcelPackage(
                "Gender.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Gender"));

                    AddHeader(
                        sheet,
                        L("Code"),
                        L("Name"),
                        L("IsDeleted")
                        );

                    AddObjects(
                        sheet, 2, gender,
                        _ => _.Gender.Code,
                        _ => _.Gender.Name,
                        _ => _.Gender.IsDeleted
                        );

                });
        }
    }
}