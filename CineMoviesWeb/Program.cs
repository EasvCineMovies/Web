using System.Globalization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace CineMoviesWeb;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var cultureInfo = new CultureInfo("en-DK");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            await builder.Build().RunAsync();
        }
    }