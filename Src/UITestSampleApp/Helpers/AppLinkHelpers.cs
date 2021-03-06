﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UITestSampleApp
{
    public static class AppLinkHelpers
    {
        public static string BaseUrl => "https://uitestsampleapp.minnick.com/";

        public static AppLinkEntry CreateAppLink(string title, string description, string id, string iconName = "")
        {
            var url = $"{BaseUrl}{id}";

            var entry = new AppLinkEntry
            {
                Title = title,
                Description = description,
                AppLinkUri = new Uri(url, UriKind.RelativeOrAbsolute),
                IsLinkActive = true
            };

            if (Device.RuntimePlatform is Device.iOS && !string.IsNullOrEmpty(iconName))
                entry.Thumbnail = ImageSource.FromFile(iconName);

            return entry;
        }

        internal static Task NavigateToListViewPage()
        {
            // Navigate to List View Page by recreating the Navigation Stack to mimic the user journey
            return Device.InvokeOnMainThreadAsync(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(new ListPage());
            });
        }
    }
}

