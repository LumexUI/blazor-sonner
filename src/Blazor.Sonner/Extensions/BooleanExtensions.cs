namespace Blazor.Sonner.Extensions;

internal static class BooleanExtensions
{
	public static string ToAttr( this bool value ) => value ? "true" : "false";
}
