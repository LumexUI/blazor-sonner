using Blazor.Sonner.Common;

namespace Blazor.Sonner.Services;

public class ToastService
{
	internal event EventHandler<ToastModel>? OnShow;

	public void Show( string title, ToastModel? data = null )
		=> Show( ToastType.Default, title, data );

	public void Success( string title, ToastModel? data = null )
		=> Show( ToastType.Success, title, data );

	public void Warning( string title, ToastModel? data = null )
		=> Show( ToastType.Warning, title, data );

	public void Error( string title, ToastModel? data = null )
		=> Show( ToastType.Error, title, data );

	public void Info( string title, ToastModel? data = null )
		=> Show( ToastType.Info, title, data );

	private void Show( ToastType type, string title, ToastModel? data )
	{
		var toast = new ToastModel
		{
			Id = Guid.NewGuid(),
			Type = type,
			Title = title,
			Description = data?.Description,
		};

		OnShow?.Invoke( this, toast );
	}
}
