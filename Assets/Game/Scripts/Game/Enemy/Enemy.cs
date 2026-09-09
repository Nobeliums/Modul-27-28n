using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{
	public event Action<Enemy> Destroyed;

	protected ReactiveVariable<int> _health;

	public bool IsDead => _health.Value <= 0;
	public bool IsDestroyed { get; private set; }

	public virtual void Initialize(BaseEnemyConfig config)
	{
		_health = new ReactiveVariable<int>();
		_health.Value = config.StartHealth;
	}

	private void Awake()
	{
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