
using System;

public class ReactiveVariable<T> : IReadOnlyReactiveVariable<T>
{
	public event Action<T> Changed;
	
	private T _value;

	public T Value
	{
		get => _value;
		set
		{
			_value = value;
			Changed?.Invoke(_value);
		}
	}
	
	public  ReactiveVariable() {}

	public ReactiveVariable(T startValue)
	{
		_value = startValue;
	}
}