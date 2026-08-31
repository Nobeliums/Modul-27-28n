using System;
using UnityEngine;

[Serializable]
public class Wallet : IValueChangeNotifier
{
	public event Action<int> ValueChanged;

	public int Value { get; private set; }
	public string Name { get; private set; }
	public Sprite Icon { get; private set; }
	public WalletType Type { get; private set; }

	public Wallet(WalletConfig walletConfig)
	{
		Value = walletConfig.StartValue;
		Name = walletConfig.Name;
		Icon = walletConfig.Sprite;
		Type = walletConfig.Type;
	}

	public void AddValue(int value)
	{
		Value += value;
		ValueChanged?.Invoke(Value);
	}

	public void RemoveValue(int value)
	{
		Value -= value;
		ValueChanged?.Invoke(Value);
	}

}