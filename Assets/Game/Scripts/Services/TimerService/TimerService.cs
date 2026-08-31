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
			timer.StartTimer();
		}
	}

	public void StopAllTimers()
	{
		foreach (Timer timer in _timers)
		{
			timer.StopTimer();
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