namespace Blazor.Sonner.Common;

public sealed class ToastModel
{
	public required Guid Id { get; set; }
	public string? ToasterId { get; set; }
	public string? Description { get; set; }
	public ToastPosition? Position { get; set; }

	internal string? Title { get; set; }
	internal ToastType Type { get; set; }
}

public enum ToastType
{
	Default,

	Success,

	Warning,

	Error,

	Info
}

public enum ToastPosition
{
	TopLeft,

	TopCenter,

	TopRight,

	BottomLeft,

	BottomCenter,

	BottomRight
}

public enum DocumentDirection
{
	Ltr,

	Rtl,

	Auto
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