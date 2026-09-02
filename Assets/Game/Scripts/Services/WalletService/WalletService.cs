using System;
using System.Collections.Generic;
using UnityEngine;

public class WalletService : MonoBehaviour
{
	[SerializeField] private List<WalletConfig> _walletConfigs;

	private List<Wallet> _wallets;

	public List<WalletConfig> WalletConfigs => _walletConfigs;

	public void Initialize()
	{
		_wallets = new List<Wallet>();

		foreach (var walletConfig in _walletConfigs)
		{
			if (_wallets.Find(x => x.Type == walletConfig.Type) != null)
			{
				Debug.LogWarning($"Wallet {walletConfig.Type} is already exist");
				continue;
			}

			_wallets.Add(new Wallet(walletConfig));
		}
	}

	private bool TryGetWalletBy(WalletType walletType, out Wallet wallet)
	{
		wallet = _wallets.Find(x => x.Type == walletType);

		return wallet != null;
	}

	public bool TryAddListenerTo(WalletType walletType, Action<int> callback)
	{
		if (TryGetWalletBy(walletType, out Wallet wallet))
		{
			wallet.ValueChanged += callback;
			
			return true;
		}
		
		Debug.LogWarning($"Wallet {walletType} is not exist");
		return false;
	}

	public bool TryRemoveListenerFrom(WalletType walletType, Action<int> callback)
	{
		if (TryGetWalletBy(walletType, out Wallet wallet))
		{
			wallet.ValueChanged -= callback;
			
			return true;
		}
		
		Debug.LogWarning($"Wallet {walletType} is not exist");
		return false;
	}

	public void AddValueTo(WalletType walletType, int value)
	{
		if (TryGetWalletBy(walletType, out Wallet wallet))
			wallet.AddValue(value);
		else
			Debug.LogError($"Wallet {walletType} is not exist");
	}

	public void RemoveValueFrom(WalletType walletType, int value)
	{
		if (TryGetWalletBy(walletType, out Wallet wallet))
			wallet.RemoveValue(value);
		else
			Debug.LogError($"Wallet {walletType} is not exist");
	}
}