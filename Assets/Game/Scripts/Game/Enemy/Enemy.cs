using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyeble
{
	public event Action<Enemy> Destroyed;

	[SerializeField] private int _health;
	
	public bool IsDead => _health <= 0;

	public bool IsDestroyed { get; private set; }

	private void Awake()
	{
		_health = 100;
		IsDestroyed = false;
	}

	public void Destroy()
	{
		Destroyed?.Invoke(this);
		Destroyed = null;
		
		IsDestroyed = true;
		
		Destroy(gameObject);
	}
}