namespace Blazor.Sonner.Common;

public sealed record ToastOptions
{
	public string? Description { get; set; }
}

public sealed record ToastModel
{
	public Guid Id { get; init; }
	public string? Title { get; set; }
	public string? Description { get; set; }
}

public readonly struct Offset( float top, float left, float bottom, float right )
{
	public readonly float Top = top;
	public readonly float Left = left;
	public readonly float Bottom = bottom;
	public readonly float Right = right;

	public Offset( float xy ) : this( xy, xy, xy, xy ) 
	{
	}

	public Offset( float x, float y ) : this( y, x, y, x )
	{
	}
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