using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorCalendar.Services;
using BlazorCalendar.Core;

namespace BlazorCalendar
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("Default", c =>
            {
                c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/Calendars.ReadWrite");
            });
            builder.Services.AddTransient<ICalendarEventsProvider, MicrosoftCalendarEventsProvider>();
            builder.Services.AddTransient<CalendarController>();
            await builder.Build().RunAsync();
        }
    }
}
