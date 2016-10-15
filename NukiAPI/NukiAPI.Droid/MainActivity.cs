using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace NukiAPI.Droid
{
    [Activity(Label = "NukiAPI", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            // ReSharper disable once NotAccessedVariable
            ////var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            ////x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
        }
    }
}