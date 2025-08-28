namespace Blazor.Sonner.Common;

public sealed record ToastOptions
{
	public string? Description { get; set; }
}

public sealed record ToastModel
{
	public Guid Id { get; init; }
	public string? ToasterId { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public Position? Position { get; set; }
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

public readonly struct Height( Guid toastId, double value )
{
	public readonly Guid ToastId = toastId;
	public readonly double Value = value;
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

internal sealed record BoundingClientRect
{
	public double X { get; set; }
	public double Y { get; set; }
	public double Width { get; set; }
	public double Height { get; set; }
	public double Top { get; set; }
	public double Right { get; set; }
	public double Bottom { get; set; }
	public double Left { get; set; }
}