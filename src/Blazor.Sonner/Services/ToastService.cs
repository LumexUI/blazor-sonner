using Blazor.Sonner.Common;

namespace Blazor.Sonner.Services;

public class ToastService
{
	internal event EventHandler<ToastShowEventArgs>? OnShow;

	public void Show( string message, ToastOptions? options = null )
	{
		var toast = new ToastModel
		{
			Id = Guid.NewGuid(),
			Title = message,
			Description = options?.Description
		};

		OnShow?.Invoke( this, new ToastShowEventArgs( toast ) );
	}
}
