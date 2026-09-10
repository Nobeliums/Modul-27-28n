using System;
using UnityEngine;

[Serializable]
public class BaseEnemyConfig
{
	[SerializeField] private int _startHealth;
	[SerializeField] private Enemy _enemyPrefab;
	
	public int StartHealth => _startHealth;
	public Enemy EnemyPrefab => _enemyPrefab;
}