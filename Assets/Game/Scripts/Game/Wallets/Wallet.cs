using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Wallet
{
	private List<Currency> _currencies;
	private List<CurrencyConfig> _currencyConfig;
	
	public IReadOnlyList<Currency> Currencies => _currencies;
	public IReadOnlyList<CurrencyConfig> CurrencyConfigs => _currencyConfig;

	public Wallet(params CurrencyConfig[] currencyConfigs)
	{
		_currencies = new List<Currency>();
		_currencyConfig = new List<CurrencyConfig>();

		foreach (CurrencyConfig walletConfig in currencyConfigs)
		{
			Currency currency = new Currency(walletConfig);
			_currencyConfig.Add(walletConfig);
			
			_currencies.Add(currency);
		}
	}

	public void AddValueTo(CurrencyType type, int value)
	{
		if (value < 0)
			throw new ArgumentOutOfRangeException("Value cannot be negative");
		
		if (TryGetCurrencyBy(type, out Currency currency) == false)
			throw new ArgumentException($"{type.ToString()} is not a valid currency");
		
		currency.Add(value);
	}

	public void RemoveValueFrom(CurrencyType type, int value)
	{
		if (value < 0)
			throw new ArgumentOutOfRangeException("Value cannot be negative");
		
		if (TryGetCurrencyBy(type, out Currency currency) == false)
			throw new ArgumentException($"{type.ToString()} is not a valid currency");
		
		currency.Remove(value);
	}

	public IReadOnlyCurrency GetCurrencyValueBy(CurrencyType type)
	{
		if (TryGetCurrencyBy(type, out Currency currency))
			return currency;
		
		throw new ArgumentException($"{type.ToString()} is not a valid currency");
	}

	private bool TryGetCurrencyBy(CurrencyType type, out Currency currency)
	{
		currency = _currencies.FirstOrDefault(c => c.Type == type);

		if (currency == null)
		{
			Debug.LogWarning($"{type.ToString()} is not created");
			return false;
		}
		
		return true;
	}
}