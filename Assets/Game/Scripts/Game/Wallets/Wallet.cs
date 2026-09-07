using System;
using UnityEngine;

[Serializable]
public class Wallet
{
	private ReactiveVariable<int> _value;
	public string Name { get; private set; }
	public Sprite Icon { get; private set; }
	public WalletType Type { get; private set; }
	
	public IReadOnlyReactiveVariable<int> Value => _value;

	public Wallet(WalletConfig walletConfig)
	{
		_value = new ReactiveVariable<int>();
		_value.Value = walletConfig.StartValue;
		Name = walletConfig.Name;
		Icon = walletConfig.Sprite;
		Type = walletConfig.Type;
	}

	public void AddValue(int value)
	{
		if (value < 0)
			throw new ArgumentOutOfRangeException("Value cannot be negative");

		_value.Value += value;
	}

	public void RemoveValue(int value)
	{
		if (value < 0)
			throw new ArgumentOutOfRangeException("Value cannot be negative");
		_value.Value -= value;
	}

}