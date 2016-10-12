using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NukiAPI.Helpers;
using NukiAPI.Properties;
using NukiAPI.WebAPI;

namespace NukiAPI
{
    public class NukiActions
    {
        private readonly MainPage mainPage;
        private LockInfo info;

        private string token => Settings.ApiKey;

        public NukiActions(MainPage mainPage)
        {
            ////ServicePointManager.ServerCertificateValidationCallback = (s, c, ch, e) => true; // Ignore errors
            this.mainPage = mainPage;
        }

        public async Task LoadLocks(HttpClient client)
        {
            mainPage.IsActive = true;
            mainPage.Status = Resources.LoadingLocks;

            var response = await client.GetAsync($"list?token={token}");
            if (!response.IsSuccessStatusCode)
                return;

            var result = await response.Content.ReadAsStringAsync();
            var state = JsonConvert.DeserializeObject<IEnumerable<LockInfo>>(result);
            info = state.First();
            await UpdateState(client);

            mainPage.IsActive = false;
        }

        public async Task UpdateState()
        {
            using (var client = GetClient())
            {
                if (Settings.LockId > 0)
                {
                    info = new LockInfo() { NukiId = Settings.LockId, Name = Settings.LockName };
                    mainPage.IsActive = true;
                    await UpdateState(client);
                    mainPage.IsActive = false;
                }
                else
                    await LoadLocks(client);
            }
        }
        public async Task UpdateState(HttpClient client)
        {
            mainPage.Status = Resources.UpdatingStatus;
            var response = await client.GetAsync($"lockState?nukiId={info.NukiId}&token={token}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var state = JsonConvert.DeserializeObject<LockStateInfo>(result);

                string stateName = state.State.ToString();
                switch (state.State)
                {
                    case LockState.Locked: stateName = Resources.Locked; break;
                    case LockState.Unlocked: stateName = Resources.Unlocked; break;
                }
                mainPage.Status = $"{info.Name}: {stateName}";
            }
        }

        public async Task PerformActionAsync(LockAction action)
        {
            mainPage.IsActive = true;

            using (var client = GetClient())
            {
                var response = await client.GetAsync($"lockAction?nukiId={info.NukiId}&action={(int)action}&token={token}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var state = JsonConvert.DeserializeObject<LockActionResult>(result);
                    if (state.Success)
                        await UpdateState(client);
                    else
                        mainPage.Status = Resources.ActionFailed;
                }
            }

            mainPage.IsActive = false;
        }

        public static HttpClient GetClient(string baseUri = null)
        {
            var client = new HttpClient() { BaseAddress = new Uri(baseUri ?? Settings.BaseUri) };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}