using System.Diagnostics;

namespace Blazor.Sonner.Common;

internal sealed class ToastTimer( TimeSpan duration ) : IDisposable
{
	private readonly Stopwatch _stopwatch = new();

	private CancellationTokenSource? _cts;
	private TimeSpan _pausedElapsed = TimeSpan.Zero;

	public event Action? OnCompleted;

	private TimeSpan Remaining
	{
		get
		{
			var elapsed = _pausedElapsed + (_stopwatch.IsRunning ? _stopwatch.Elapsed : TimeSpan.Zero);
			var rem = duration - elapsed;
			return rem <= TimeSpan.Zero ? TimeSpan.Zero : rem;
		}
	}

	public void Start() => StartCore();

	public void Pause()
	{
		if( !_stopwatch.IsRunning )
		{
			return;
		}

		_stopwatch.Stop();
		_pausedElapsed += _stopwatch.Elapsed;

		Cleanup();
	}

	public void Resume()
	{
		if( _stopwatch.IsRunning )
		{
			return;
		}

		StartCore();
	}

	private async Task RunAsync( CancellationToken ct )
	{
		try
		{
			var remaining = Remaining;
			if( remaining <= TimeSpan.Zero )
			{
				OnCompleted?.Invoke();
				return;
			}

			await Task.Delay( remaining, ct );
			OnCompleted?.Invoke();
		}
		catch( TaskCanceledException )
		{
			// paused or disposed
		}
	}

	private void StartCore()
	{
		_stopwatch.Restart();

		_cts?.Cancel();
		_cts?.Dispose();
		_cts = new CancellationTokenSource();

		_ = RunAsync( _cts.Token );
	}

	private void Cleanup()
	{
		_cts?.Cancel();
		_cts?.Dispose();
		_cts = null;
	}

	public void Dispose()
	{
		_stopwatch.Stop();
		Cleanup();
	}
}
