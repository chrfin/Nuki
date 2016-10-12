using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using NukiAPI.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NukiAPI.Helpers
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo ci;
        private const string ResourceId = "NukiAPI.Properties.Resources";

        public TranslateExtension()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
                ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return String.Empty;

            ResourceManager resmgr = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException($"Key '{Text}' was not found in resources '{ResourceId}' for culture '{ci.Name}'.", "Text");
#else
                translation = Text;
#endif
            }
            return translation;
        }
    }
}