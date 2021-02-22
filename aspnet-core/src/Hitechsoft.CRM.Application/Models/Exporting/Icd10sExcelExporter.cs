using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hitechsoft.CRM.DataExporting.Excel.NPOI;
using Hitechsoft.CRM.Models.Dtos;
using Hitechsoft.CRM.Dto;
using Hitechsoft.CRM.Storage;

namespace Hitechsoft.CRM.Models.Exporting
{
    public class Icd10sExcelExporter : NpoiExcelExporterBase, IIcd10sExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public Icd10sExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetIcd10ForViewDto> icd10s)
        {
            return CreateExcelPackage(
                "Icd10s.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Icd10s"));

                    AddHeader(
                        sheet,
                        L("Code"),
                        L("Name"),
                        L("DiseaseChapterCode"),
                        L("DiseaseChapterName"),
                        L("WHOeName"),
                        L("WHOName"),
                        L("Status")
                        );

                    AddObjects(
                        sheet, 2, icd10s,
                        _ => _.Icd10.Code,
                        _ => _.Icd10.Name,
                        _ => _.Icd10.DiseaseChapterCode,
                        _ => _.Icd10.DiseaseChapterName,
                        _ => _.Icd10.WHOeName,
                        _ => _.Icd10.WHOName,
                        _ => _.Icd10.Status
                        );

                });
        }
    }
}