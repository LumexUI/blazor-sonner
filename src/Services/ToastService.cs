using Blazor.Sonner.Common;

namespace Blazor.Sonner.Services;

public class ToastService
{
	internal event EventHandler<ToastModel>? OnShow;
	internal event EventHandler? OnDismissAll;

	public void Show( string title, Action<ToastModel>? options = null )
		=> Show( ToastType.Default, title, options );

	public void Success( string title, Action<ToastModel>? options = null )
		=> Show( ToastType.Success, title, options );

	public void Warning( string title, Action<ToastModel>? options = null )
		=> Show( ToastType.Warning, title, options );

	public void Error( string title, Action<ToastModel>? options = null )
		=> Show( ToastType.Error, title, options );

	public void Info( string title, Action<ToastModel>? options = null )
		=> Show( ToastType.Info, title, options );

	public void DismissAll()
	{
		OnDismissAll?.Invoke( this, EventArgs.Empty );
	}

	private void Show( ToastType type, string title, Action<ToastModel>? options )
	{
		var toast = new ToastModel
		{
			Id = Guid.NewGuid(),
			Type = type,
			Title = title,
		};

		options?.Invoke( toast );
		OnShow?.Invoke( this, toast );
	}
}
