using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerService : MonoBehaviour
{
	private List<DestroyableByConditionItem> _destroyableContainer;

	public void Initialize()
	{
		_destroyableContainer = new List<DestroyableByConditionItem>();
	}

	public void Registry(IDestroyable destroyable, Func<bool> condition)
	{
		_destroyableContainer.Add(new DestroyableByConditionItem(destroyable, condition));
	}

	private void Update()
	{
		CheckDestroyConditions();
	}

	private void CheckDestroyConditions()
	{
		for (int i = _destroyableContainer.Count - 1; i >= 0; i--)
		{
			if (_destroyableContainer[i].Destroyable == null || _destroyableContainer[i].Destroyable.IsDestroyed)
			{
				_destroyableContainer.RemoveAt(i);
				continue;
			}
			
			if (_destroyableContainer[i].Condition?.Invoke() ?? false)
			{
				_destroyableContainer[i].Destroyable.Destroy();
				_destroyableContainer.RemoveAt(i);
			}
		}
	}

	private class DestroyableByConditionItem
	{
		public IDestroyable Destroyable;
		public Func<bool> Condition;

		public DestroyableByConditionItem(IDestroyable destroyable, Func<bool> condition)
		{
			Destroyable = destroyable;
			Condition = condition;
		}
	}
}