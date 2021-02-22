using System;
using Hitechsoft.CRM.Core;
using Hitechsoft.CRM.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hitechsoft.CRM.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return Text;
            }

            return L.Localize(Text);
        }
    }
}