using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerService : MonoBehaviour
{
	public event Action<Timer> TimerCreated;

	private List<Timer> _timers;
	
	public void Initialize()
	{
		_timers = new List<Timer>();
	}

	public void StartTimer(Timer timer)
	{
		timer.StartTimer();
	}

	public void StopTimer(Timer timer)
	{
		timer.StopTimer();
	}

	public void StartAllTimers()
	{
		foreach (Timer timer in _timers)
		{
			timer.StartTimer();
		}
	}

	public void StopAllTimers()
	{
		for (int i = _timers.Count - 1; i >= 0; i--)
		{
			_timers[i].StopTimer();
			_timers.RemoveAt(i);
		}
	}

	public Timer CreateTimer(int time)
	{
		Timer newTimer = new Timer(time, this);
		_timers.Add(newTimer);
		
		TimerCreated?.Invoke(newTimer);
		return newTimer;
	}
}