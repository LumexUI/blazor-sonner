using Blazor.Sonner.Docs.Components;
using Blazor.Sonner.Extensions;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

builder.Services.AddSonner();

var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() )
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler( "/Error", createScopeForErrors: true );
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.UseStaticFiles();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies( typeof( Blazor.Sonner.Docs.Client._Imports ).Assembly );

app.Run();
