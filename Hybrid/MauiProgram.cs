﻿using App;
using CommunityToolkit.Maui;

/* Unmerged change from project 'Hybrid (net7.0-android)'
Before:
using App;
After:
using Microsoft.Extensions.Configuration;
*/

/* Unmerged change from project 'Hybrid (net7.0-ios)'
Before:
using App;
After:
using Microsoft.Extensions.Configuration;
*/

/* Unmerged change from project 'Hybrid (net7.0-windows10.0.19041.0)'
Before:
using App;
After:
using Microsoft.Extensions.Configuration;
*/
using Microsoft.Extensions.Logging;

namespace Hybrid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            }).UseMauiCommunityToolkit();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddBlazorApp();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            //builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}