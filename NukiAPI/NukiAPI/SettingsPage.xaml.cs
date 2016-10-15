using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NukiAPI.Helpers;
using NukiAPI.WebAPI;
using Xamarin.Forms;

namespace NukiAPI
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            EntryBaseUri.Text = Settings.BaseUri;
            EntryApiKey.Text = Settings.ApiKey;
            SwitchConfirmLock.IsToggled = Settings.ConfirmLock;
            SwitchConfirmUnlock.IsToggled = Settings.ConfirmUnlock;
        }

        private async void SettingsPage_OnAppearing(object sender, EventArgs e)
        {
            // without setting to true once it always spinns
            ActivityIndicatorBusy.IsRunning = true;
            await Task.Delay(100);
            ActivityIndicatorBusy.IsRunning = false;
        }

        private async void ButtonSave_OnClicked(object sender, EventArgs e)
        {
            try
            {
                ActivityIndicatorBusy.IsRunning = true;
                using (var client = NukiActions.GetClient(EntryBaseUri.Text))
                {
                    var response = await client.GetAsync($"list?token={EntryApiKey.Text}");
                    if (!response.IsSuccessStatusCode)
                    {
                        await DisplayAlert(Properties.Resources.NoLocksFoundHeader, Properties.Resources.NoLocksFound, Properties.Resources.OK);
                        return;
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    var state = JsonConvert.DeserializeObject<IEnumerable<LockInfo>>(result).ToList();
                    if (!state.Any())
                    {
                        await DisplayAlert(Properties.Resources.NoLocksFoundHeader, Properties.Resources.NoLocksFound, Properties.Resources.OK);
                        return;
                    }

                    Settings.LockId = state.First().NukiId;
                    Settings.LockName = state.First().Name;
                }
            }
            catch (Exception)
            {
                ActivityIndicatorBusy.IsRunning = false;
                await DisplayAlert(Properties.Resources.NoLocksFoundHeader, Properties.Resources.NoLocksFound, Properties.Resources.OK);
                return;
            }

            Settings.BaseUri = EntryBaseUri.Text;
            Settings.ApiKey = EntryApiKey.Text;
            Settings.ConfirmLock = SwitchConfirmLock.IsToggled;
            Settings.ConfirmUnlock = SwitchConfirmUnlock.IsToggled;

            await Navigation.PopAsync(true);
        }
    }
}