using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyValueView  : BaseView
{
	[SerializeField] private TMP_Text _walletValue;
	[SerializeField] private Image _walletImage;

	private IReadOnlyCurrency _currency;
	private CurrencyConfig _currencyConfig;
	
	public void Initialize(IReadOnlyCurrency currency, CurrencyConfig currencyConfig)
	{
		_currency = currency;
		_currencyConfig = currencyConfig;
		_walletImage.sprite = _currencyConfig.Sprite;
		_walletValue.text = _currencyConfig.StartValue.ToString();
		
		_currency.Value.Changed += OnChanged;
	}

	private void OnDestroy()
	{
		_currency.Value.Changed -= OnChanged;
	}

	private void OnChanged(int newValue)
	{
		_walletValue.text = newValue.ToString();
	}
}