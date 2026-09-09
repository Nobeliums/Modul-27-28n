using System;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationStarter : MonoBehaviour
{
	public event Action GameStarted;

	[SerializeField] private List<CurrencyConfig> _currencyConfigs;
	[SerializeField] private UiService _uiService;
	[SerializeField] private TimerService _timerService;
	[SerializeField] private DestroyerService _destroyableContainer;
	[SerializeField] private EnemySpawner _enemySpawner;
	[SerializeField] private EventsExample _eventsExample;

	private void Awake()
	{
		StartGame();
	}

	private void StartGame()
	{
		Wallet wallet = new Wallet(_currencyConfigs.ToArray());
		
		_timerService.Initialize();
		_destroyableContainer.Initialize();
		_uiService.Initialize(wallet);
		_enemySpawner.Initialize();
		_eventsExample.Initialize(wallet);
		
		GameStarted?.Invoke();
	}
}