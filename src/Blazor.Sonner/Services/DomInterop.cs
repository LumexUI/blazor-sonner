using Blazor.Sonner.Common;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Sonner.Services;

internal sealed class DomInterop
{
	private const string JavaScriptPrefix = "DOM";

	private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

	public DomInterop( IJSRuntime jsRuntime )
	{
		_moduleTask = new( () => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./_content/Blazor.Sonner/dom.js" ).AsTask() );
	}

	public async ValueTask RequestAnimationFrameAsync()
	{
		var module = await _moduleTask.Value;
		await module.InvokeVoidAsync( $"{JavaScriptPrefix}.nextFrame" );
	}

	public async ValueTask<BoundingClientRect> GetBoundingClientRectAsync( ElementReference element )
	{
		var module = await _moduleTask.Value;
		return await module.InvokeAsync<BoundingClientRect>( $"{JavaScriptPrefix}.getBoundingClientRect", element );
	}

	public async ValueTask<DocumentDirection> GetDocumentDirectionAsync()
	{
		var module = await _moduleTask.Value;
		var dir = await module.InvokeAsync<string>( $"{JavaScriptPrefix}.getDocumentDirection" );

		if( Enum.TryParse<DocumentDirection>( dir, ignoreCase: true, out var result ) )
		{
			return result;
		}

		return DocumentDirection.Ltr;
	}
}
