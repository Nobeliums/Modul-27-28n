using System;
using Unity.VisualScripting;
using UnityEngine;

public class ApplicationStarter : MonoBehaviour
{
	public event Action GameStarted;
	
	[SerializeField] private WalletService _walletService;
	[SerializeField] private UiService _uiService;

	private void Awake()
	{
		StartGame();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			_walletService.AddValueTo(WalletType.Coin, 1);
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_walletService.AddValueTo(WalletType.Diamond, 1);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_walletService.AddValueTo(WalletType.Energy, 1);
		}
	}

	public void StartGame()
	{
		_walletService.Initialize();
		_uiService.Initialize();
		
		GameStarted?.Invoke();
	}
}