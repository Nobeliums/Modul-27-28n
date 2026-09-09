using Unity.VisualScripting;

public class Currency : IReadOnlyCurrency
{
	private ReactiveVariable<int> _value;

	public IReadOnlyReactiveVariable<int> Value => _value;
	public string Name { get; private set; }
	public CurrencyType Type { get; private set; }

	public Currency(CurrencyConfig currencyConfig)
	{
		Name = currencyConfig.Name;
		Type = currencyConfig.Type;
		_value = new ReactiveVariable<int>(currencyConfig.StartValue);
	}

	public void Add(int value)
	{
		_value.Value += value;
	}

	public void Remove(int value)
	{
		_value.Value -= value;
	}

}