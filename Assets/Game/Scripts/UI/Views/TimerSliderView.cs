using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : TimerView
{
	[SerializeField] private Slider _slider;

	public override void Initialize(Timer timer)
	{
		base.Initialize(timer);

		_slider.value = _timer.Time;
	}

	protected override void OnValueChanged(int value)
	{
		base.OnValueChanged(value);

		_slider.value = (float)value / _timer.Time;
	}
}