using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NukiAPI.Helpers;
using NukiAPI.WebAPI;
using Xamarin.Forms;

namespace NukiAPI
{
    public partial class MainPage : ContentPage
    {
        public bool IsActive { get { return ActivityIndicatorLoading.IsRunning; } set { ActivityIndicatorLoading.IsRunning = value; } }
        public string Status { get { return LabelHeader.Text; } set { LabelHeader.Text = value; } }

        public MainPage() { InitializeComponent(); }

        private async void MainPage_OnAppearing(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Settings.BaseUri) || String.IsNullOrWhiteSpace(Settings.ApiKey))
                await Navigation.PushAsync(new SettingsPage());
            else
                await App.NukiActions.UpdateState();
        }

        private async void ButtonLock_OnClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(Properties.Resources.LockHeader, Properties.Resources.LockTheNuki, Properties.Resources.Yes, Properties.Resources.No))
                await App.NukiActions.PerformActionAsync(LockAction.Lock);
        }

        private async void ButtonUnlock_OnClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(NukiAPI.Properties.Resources.UnlockHeader, Properties.Resources.UnlockTheNuki, Properties.Resources.Yes, Properties.Resources.No))
                await App.NukiActions.PerformActionAsync(LockAction.Unlock);
        }

        private async void ButtonSettings_OnClicked(object sender, EventArgs e) { await Navigation.PushAsync(new SettingsPage()); }
    }
}