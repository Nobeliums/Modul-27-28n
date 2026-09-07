using System;

public abstract class TimerView : BaseView
{
	protected Timer _timer;

	public virtual void Initialize(Timer timer)
	{
		_timer = timer;
		_timer.TimeLeft.ValueChanged += OnValueChanged;
	}

	private void OnDestroy()
	{
		_timer.TimeLeft.ValueChanged -= OnValueChanged;
	}

	protected virtual void OnValueChanged(int time)
	{
		if (time <= 0)
			Destroy(gameObject);
	}
}