using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{
	public event Action<Enemy> Destroyed;

	protected ReactiveVariable<int> _health;
	private SpriteRenderer _spriteRenderer;

	public bool IsDead => _health.Value <= 0;
	public bool IsDestroyed { get; private set; }

	public virtual void Initialize(BaseEnemyConfig config)
	{
		_health = new ReactiveVariable<int>();
		_health.Value = config.StartHealth;
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_spriteRenderer.sprite = config.Sprite;
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