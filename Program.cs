using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ConsumoAPI2.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuraci�n para producci�n/desarrollo
var apiBase = builder.HostEnvironment.IsProduction()
    ? "https://backsanchez-production.up.railway.app"  // URL de tu API en Railway
    : "http://localhost:5216";             // URL local de tu API

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBase)
});

await builder.Build().RunAsync();
