using System;
using UnityEngine;

[Serializable]
public class DragonEnemyConfig : BaseEnemyConfig
{
	[SerializeField] private int _fireDamage;
	[SerializeField] private int _fireRange;
	
	public int FireDamage => _fireDamage;
	public int FireRange => _fireRange;
}