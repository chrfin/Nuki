using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace NukiAPI.Droid
{
    [Activity(Label = "NukiAPI", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // set the layout resources first
            ////FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            ////FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

            // then call base.OnCreate and the Xamarin.Forms methods
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}