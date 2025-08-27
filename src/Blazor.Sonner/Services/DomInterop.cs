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
}
