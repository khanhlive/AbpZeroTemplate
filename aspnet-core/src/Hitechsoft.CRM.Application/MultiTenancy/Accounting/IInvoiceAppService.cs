using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Hitechsoft.CRM.MultiTenancy.Accounting.Dto;

namespace Hitechsoft.CRM.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
