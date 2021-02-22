using System.Threading.Tasks;
using Abp.Dependency;

namespace Hitechsoft.CRM.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}