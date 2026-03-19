using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using daphine;
using Daphine.Services;
using Daphine.Services.Games;
using Daphine.Services.Characters;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<GameService>();
builder.Services.AddSingleton<AnimalClickGameService>();
builder.Services.AddSingleton<NumbersClickGameService>();
builder.Services.AddSingleton<ColorClickGameService>();
builder.Services.AddSingleton<DaphineCharacterService>();

await builder.Build().RunAsync();
