namespace Blazor.Sonner.Common;

public sealed record ToastModel
{
	public Guid Id { get; init; }
	public string? Title { get; set; }
	public string? Description { get; set; }
}

public sealed record ToastOptions
{
	public string? Description { get; set; }
}

public enum Position
{
	TopLeft,

	TopCenter,

	TopRight,

	BottomLeft,

	BottomCenter,

	BottomRight
}

internal sealed class ToastShowEventArgs : EventArgs
{
	public ToastModel Toast { get; }

	public ToastShowEventArgs( ToastModel toast )
	{
		Toast = toast;
	}
}