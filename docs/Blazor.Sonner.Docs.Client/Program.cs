using Blazor.Sonner.Extensions;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSonner();

await builder.Build().RunAsync();
