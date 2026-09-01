using System;
using Unity.VisualScripting;
using UnityEngine;

public class ApplicationStarter : MonoBehaviour
{
	public event Action GameStarted;
	
	[SerializeField] private WalletService _walletService;
	[SerializeField] private UiService _uiService;
	[SerializeField] private TimerService _timerService;
	[SerializeField] private DestroyerService _destroyebleContainer;
	[SerializeField] private EnemySpawner _enemySpawner;

	private void Awake()
	{
		StartGame();
	}

	public void StartGame()
	{
		_walletService.Initialize();
		_timerService.Initialize();
		_destroyebleContainer.Initialize();
		_uiService.Initialize();
		_enemySpawner.Initialize();
		
		GameStarted?.Invoke();
	}
}