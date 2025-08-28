using System.Diagnostics;

namespace Blazor.Sonner.Common;

internal sealed class ToastTimer( TimeSpan duration ) : IDisposable
{
	private readonly Stopwatch _stopwatch = new();
	private readonly TimeSpan _tickInterval = TimeSpan.FromMilliseconds( duration.TotalMilliseconds / 100 );

	private CancellationTokenSource? _cts;
	private TimeSpan _pausedElapsed = TimeSpan.Zero;

	public event Action? Completed;

	public TimeSpan Remaining =>
		duration - (_pausedElapsed + (_stopwatch.IsRunning ? _stopwatch.Elapsed : TimeSpan.Zero));

	public void Start()
	{
		_pausedElapsed = TimeSpan.Zero;
		StartCore();
	}

	public void Pause()
	{
		if( !_stopwatch.IsRunning )
		{
			return;
		}

		_cts?.Cancel();
		_cts?.Dispose();
		_stopwatch.Stop();
		_pausedElapsed += _stopwatch.Elapsed;
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
			while( !ct.IsCancellationRequested )
			{
				await Task.Delay( _tickInterval, ct );

				if( Remaining <= TimeSpan.Zero )
				{
					Completed?.Invoke();
					break;
				}
			}
		}
		catch( TaskCanceledException ) { /* ignore */ }
	}

	private void StartCore()
	{
		_cts = new CancellationTokenSource();
		_stopwatch.Restart();
		_ = RunAsync( _cts.Token );
	}

	public void Dispose()
	{
		_cts?.Cancel();
		_cts?.Dispose();
		_stopwatch.Stop();
	}
}
