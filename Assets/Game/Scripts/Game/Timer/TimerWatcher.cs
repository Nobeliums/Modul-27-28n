public class TimerWatcher
{
	private bool _isTimerFinished;

	private Timer _timer;

	public TimerWatcher(Timer timer)
	{
		_timer = timer;
		_isTimerFinished = false;
		_timer.TimerFinished += OnTimerFinished;
		_timer.TimerStopped += TimerStopped;
	}
	
	public void OnTimerFinished() => _isTimerFinished = true;

	public bool IsTimerFinished()
	{
		if (_isTimerFinished)
		{
			TimerStopped();
		}

		return _isTimerFinished;
	}

	private void TimerStopped()
	{
		_timer.TimerFinished -= OnTimerFinished;
		_timer.TimerStopped -= TimerStopped;
	}
}