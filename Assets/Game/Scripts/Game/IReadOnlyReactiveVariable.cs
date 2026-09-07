using System;

public interface IReadOnlyReactiveVariable<T>
{
	public event Action<T> ValueChanged;
	
	public T Value { get; }
}