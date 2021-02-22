using Xamarin.Forms.Internals;

namespace Hitechsoft.CRM.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}