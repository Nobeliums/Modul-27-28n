using System;
using System.Collections;
using UnityEngine;

public class Timer
{
	public event Action<int> ValueChanged;
	public event Action TimerFinished;
	public event Action TimerStopped;

	private int _time;
	private int _timeLeft;

	private MonoBehaviour _coroutineStarter;
	private Coroutine _process;
	
	public Timer(int time,  MonoBehaviour coroutineStarter)
	{
		_time = time;
		_timeLeft = time;
		_coroutineStarter = coroutineStarter;
	}

	public int Time => _time;

	public void StartTimer()
	{
		if (_process == null)
			_process = _coroutineStarter.StartCoroutine(ProcessTimer());
		else
			Debug.LogWarning("Timer is already running");
	}

	public void StopTimer()
	{
		if (_process == null)
			return;

		_timeLeft = 0;

		ValueChanged?.Invoke(_timeLeft);
		TimerStopped?.Invoke();
		
		_coroutineStarter.StopCoroutine(_process);
	}

	private IEnumerator ProcessTimer()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);

			_timeLeft--;

			if (_timeLeft <= 0)
			{
				TimerFinished?.Invoke();
				StopTimer();
			}

			ValueChanged?.Invoke(_timeLeft);
		}
	}
}
