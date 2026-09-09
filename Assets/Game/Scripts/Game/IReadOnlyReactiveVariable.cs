using System;

public interface IReadOnlyReactiveVariable<T>
{
	public event Action<T> Changed;
	
	public T Value { get; }
}