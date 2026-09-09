using System;
using UnityEngine;

[Serializable]
public class BaseEnemyConfig
{
	[SerializeField] private int _startHealth;
	[SerializeField] private Sprite _sprite;
	[SerializeField] private Enemy _enemyPrefab;
	
	public int StartHealth => _startHealth;
	public Sprite Sprite => _sprite;
	public Enemy EnemyPrefab => _enemyPrefab;
}