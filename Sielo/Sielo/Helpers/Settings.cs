using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Sielo.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string HomePage
        {
            get => AppSettings.GetValueOrDefault("home_page", "https://doosearch.sielo.app");
            set => AppSettings.AddOrUpdateValue("home_page", value);
        }
    }
}