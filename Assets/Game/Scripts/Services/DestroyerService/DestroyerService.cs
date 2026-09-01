using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerService : MonoBehaviour
{
	private List<DestroyContiditonItem> _destroyeblesContainer;

	public void Initialize()
	{
		_destroyeblesContainer = new List<DestroyContiditonItem>();
	}

	public void Registry(IDestroyeble destroyeble, Func<bool> condition)
	{
		_destroyeblesContainer.Add(new DestroyContiditonItem(destroyeble, condition));
	}

	private void Update()
	{
		CheckDestroyConditions();
	}

	private void CheckDestroyConditions()
	{
		for (int i = _destroyeblesContainer.Count - 1; i >= 0; i--)
		{
			if (_destroyeblesContainer[i].Destroyeble == null || _destroyeblesContainer[i].Destroyeble.IsDestroyed)
			{
				_destroyeblesContainer.RemoveAt(i);
				continue;
			}
			
			if (_destroyeblesContainer[i].Condition())
			{
				_destroyeblesContainer[i].Destroyeble.Destroy();
				_destroyeblesContainer.RemoveAt(i);
			}
		}
	}

	internal class DestroyContiditonItem
	{
		public IDestroyeble Destroyeble;
		public Func<bool> Condition;

		public DestroyContiditonItem(IDestroyeble destroyeble, Func<bool> condition)
		{
			Destroyeble = destroyeble;
			Condition = condition;
		}
	}
}