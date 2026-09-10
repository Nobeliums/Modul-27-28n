using System;
using System.Collections;
using UnityEngine;

public class Timer
{ 
	public event Action TimerFinished;
	public event Action TimerStopped;

	private int _time;
	private ReactiveVariable<int> _timeLeft;
	private MonoBehaviour _coroutineStarter;
	private Coroutine _process;
	
	public Timer(int time,  MonoBehaviour coroutineStarter)
	{
		_timeLeft = new ReactiveVariable<int>();
		_time = time;
		_timeLeft.Value = time;
		_coroutineStarter = coroutineStarter;
	}
	
	public IReadOnlyReactiveVariable<int> TimeLeft => _timeLeft;
	public bool IsRunning => _process != null;

	public int Time => _time;

	public void StartTimer()
	{
		if (IsRunning == false)
			_process = _coroutineStarter.StartCoroutine(ProcessTimer());
		else
			Debug.LogWarning("Timer is already running");
	}

	public void StopTimer()
	{
		if (IsRunning)
			return;

		_timeLeft.Value = 0;
		
		TimerStopped?.Invoke();
		
		_coroutineStarter.StopCoroutine(_process);
	}

	private IEnumerator ProcessTimer()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);

			_timeLeft.Value--;

			if (_timeLeft.Value <= 0)
			{
				TimerFinished?.Invoke();
				StopTimer();
			}
		}
	}
}
