using Blazor.Sonner.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Sonner.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddSonner( this IServiceCollection services )
	{
		services.AddScoped<ToastService>();
		services.AddScoped<DomInterop>();
	}
}
