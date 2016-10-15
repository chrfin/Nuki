using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NukiAPI.Interfaces;
using Xamarin.Forms;

namespace NukiAPI
{
    public partial class App
    {
        public static NukiActions NukiActions { get; private set; }

        public App()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                NukiAPI.Properties.Resources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }

            InitializeComponent();

            // The root page of your application
            var mainPage = new MainPage();
            NukiActions = new NukiActions(mainPage);
            MainPage = new NavigationPage(mainPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnResume()
        {
            // Handle when your app resumes
            await NukiActions.UpdateState();
        }
    }
}