using System.Threading.Tasks;
using Hitechsoft.CRM.Views;
using Xamarin.Forms;

namespace Hitechsoft.CRM.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
