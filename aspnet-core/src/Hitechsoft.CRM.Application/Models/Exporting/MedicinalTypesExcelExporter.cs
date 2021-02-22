using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hitechsoft.CRM.DataExporting.Excel.NPOI;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;
using Hitechsoft.CRM.Storage;

namespace Hitechsoft.CRM.Models.Exporting
{
    public class MedicinalTypesExcelExporter : NpoiExcelExporterBase, IMedicinalTypesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public MedicinalTypesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetMedicinalTypeForViewDto> medicinalTypes)
        {
            return CreateExcelPackage(
                "MedicinalTypes.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("MedicinalTypes"));

                    AddHeader(
                        sheet,
                        L("Code"),
                        L("Name"),
                        L("Description"),
                        L("Status"),
                        L("IsDeleted")
                        );

                    AddObjects(
                        sheet, 2, medicinalTypes,
                        _ => _.MedicinalType.Code,
                        _ => _.MedicinalType.Name,
                        _ => _.MedicinalType.Description,
                        _ => _.MedicinalType.Status,
                        _ => _.MedicinalType.IsDeleted
                        );

                });
        }
    }
}