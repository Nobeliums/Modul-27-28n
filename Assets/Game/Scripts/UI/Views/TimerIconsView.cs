using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerIconsView : TimerView
{
	[SerializeField] private GameObject _iconPrefab;
	[SerializeField] private RectTransform _iconsGrid;

	private Queue<GameObject> _icons;

	public override void Initialize(Timer timer)
	{
		base.Initialize(timer);
		
		_icons = new Queue<GameObject>();

		for (int i = 0; i < _timer.Time; i++)
		{
			GameObject newIcon = Instantiate(_iconPrefab, _iconsGrid);
			
			_icons.Enqueue(newIcon);
		}
	}
	
	protected override void OnValueChanged(int time)
	{
		base.OnValueChanged(time);
		
		GameObject icon =  _icons.Dequeue();
		
		Destroy(icon);
	}
}