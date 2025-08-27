using System.Text;

namespace Blazor.Sonner.Common;

internal static class Utils
{
	public static string GetOffset( Offset? offset, Offset? mobileOffset )
	{
		var styles = new StringBuilder();
		var offsets = new Offset?[] { offset, mobileOffset };

		for( var index = 0; index < offsets.Length; index++ )
		{
			var current = offsets[index];
			var isMobile = index == 1;
			var prefix = isMobile ? "--mobile-offset" : "--offset";
			var defaultValue = isMobile ? Constants.MobileViewportOffset : Constants.ViewportOffset;

			if( current is null )
			{
				AssignAll( prefix, new Offset( defaultValue ) );
			}
			else
			{
				AssignAll( prefix, current.Value );
			}
		}

		return styles.ToString();

		void AssignAll( string prefix, Offset offset )
		{
			var offsetToSide = new Dictionary<string, float>
			{
				["top"] = offset.Top,
				["left"] = offset.Left,
				["bottom"] = offset.Bottom,
				["right"] = offset.Right
			};

			foreach( var (key, value) in offsetToSide )
			{
				styles.Append( $"{prefix}-{key}: {value}px; " );
			}
		}
	}
}
