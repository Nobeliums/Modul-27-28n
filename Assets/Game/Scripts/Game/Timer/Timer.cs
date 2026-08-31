using System;
using System.Collections;
using UnityEngine;

public class Timer : IValueChangeNotifier
{
	public event Action<int> ValueChanged;

	private int _time;
	private int _timeLeft;
	
	public int Time => _time;

	private MonoBehaviour _coroutineStarter;
	private Coroutine _process;
	
	public Timer(int time,  MonoBehaviour coroutineStarter)
	{
		_time = time;
		_timeLeft = time;
		_coroutineStarter = coroutineStarter;
	}

	public void StartTimer()
	{
		if (_process == null)
			_coroutineStarter.StartCoroutine(ProcessTimer());
		else
			Debug.LogError("Timer is already running");
	}

	public void StopTimer()
	{
		if (_process == null)
			return;
		
		_coroutineStarter.StopCoroutine(_process);
	}

	public IEnumerator ProcessTimer()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);

			_timeLeft--;
			ValueChanged?.Invoke(_timeLeft);

			if (_timeLeft <= 0)
			{
				yield break;
			}
		}
	}
}