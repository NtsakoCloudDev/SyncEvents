using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorApp;
using MyBlazorApp.Services;
using System.Text.RegularExpressions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<ApiService>();
builder.Services.AddScoped<UserSessionState>();
builder.Services.AddScoped<EventService>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
