using System;
using UnityEngine;

[Serializable]
public class OrkEnemyConfig : BaseEnemyConfig
{
	[SerializeField] private int _startForce;
	[SerializeField] private int _startRage;
	
	public int StartForce => _startForce;
	public int StartRage => _startRage;
}