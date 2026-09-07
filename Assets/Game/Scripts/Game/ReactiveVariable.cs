
using System;

public class ReactiveVariable<T> : IReadOnlyReactiveVariable<T>
{
	public event Action<T> ValueChanged;
	
	private T _value;

	public T Value
	{
		get => _value;
		set
		{
			_value = value;
			ValueChanged?.Invoke(_value);
		}
	}
}