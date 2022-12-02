global using Blazored.SessionStorage;
global using MudBlazorTest.Client.Authentication;
global using MudBlazorTest.Client.Services.PerroService;
global using MudBlazorTest.Client.Services.PropietarioService;
global using MudBlazorTest.Client.Services.VeterinarioService;
global using MudBlazorTest.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazorTest.Client;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IPerroService, PerroService>();
builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
builder.Services.AddScoped<IPropietarioService, PropietarioService>();



await builder.Build().RunAsync();
