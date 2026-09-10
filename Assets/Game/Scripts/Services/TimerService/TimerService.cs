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

	public void StartAllTimers()
	{
		foreach (Timer timer in _timers)
		{
			if (timer.IsRunning)
				continue;
			
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