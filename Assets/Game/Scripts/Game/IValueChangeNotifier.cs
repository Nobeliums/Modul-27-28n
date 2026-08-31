using System;

public interface IValueChangeNotifier
{
	public event Action<int> ValueChanged;
}