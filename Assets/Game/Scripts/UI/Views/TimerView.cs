using System;

public abstract class TimerView : BaseView
{
	protected Timer _timer;

	public virtual void Initialize(Timer timer)
	{
		_timer = timer;
		_timer.ValueChanged += OnValueChanged;
	}

	private void OnDestroy()
	{
		_timer.ValueChanged -= OnValueChanged;
	}

	protected virtual void OnValueChanged(int time)
	{
		if (time <= 0)
			Destroy(gameObject);
	}
}