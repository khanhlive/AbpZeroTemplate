using System.Threading.Tasks;

namespace Hitechsoft.CRM.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}