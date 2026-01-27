using Blazor.Sonner.Common;

namespace Blazor.Sonner.Services;

public class ToastService
{
	internal event EventHandler<ToastModel>? OnShow;
    internal event EventHandler<ToastModel>? OnUpdate;
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

    public void Async<T>( Task<T> task, Action<ToastAsyncModel<T>>? options = null ) 
		=> _ = AsyncCore( task, options ); // Fire and forget

    private async Task AsyncCore<T>( Task<T> task, Action<ToastAsyncModel<T>>? options = null)
	{
		var opts = new ToastAsyncModel<T>
		{
			Id = Guid.NewGuid()
        };

        options?.Invoke( opts );

        var toast = new ToastModel
        {
            Id = opts.Id,
            Type = ToastType.Loading,
            Title = opts.Loading,
			Description = opts.LoadingDescription ?? opts.Description,
            IsAsync = true
        };

		OnShow?.Invoke( this, toast );

        try
        {
            var result = await task;

            toast.Type = ToastType.Success;
            toast.Title = opts.Success?.Invoke( result ) ?? "Success";
            toast.Description = opts.SuccessDescription?.Invoke( result ) ?? opts.Description;

            OnUpdate?.Invoke( this, toast );
        }
        catch( Exception ex )
        {
            toast.Type = ToastType.Error;
            toast.Title = opts.Error?.Invoke( ex ) ?? "Error";
			toast.Description = opts.ErrorDescription?.Invoke( ex ) ?? opts.Description;

            OnUpdate?.Invoke( this, toast );
            throw;
        }
    }

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
