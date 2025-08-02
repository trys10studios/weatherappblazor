using BlazorWeatherApp;
using BlazorWeatherApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClient for API calls
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register your WeatherService so it can be injected
builder.Services.AddScoped<WeatherService>();

await builder.Build().RunAsync();
