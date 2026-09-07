using System;
using UnityEngine;

public class OrkEnemy : Enemy
{
	private OrkСharacteristic _characteristics;

	public override void Initialize(BaseEnemyConfig config)
	{
		if (config is OrkEnemyConfig orkConfig == false)
		{
			throw new ArgumentException($"Not valid config. {typeof(OrkEnemyConfig)} is expected");
		}
		
		base.Initialize(orkConfig);
		_characteristics = new OrkСharacteristic
		{
			Force = orkConfig.StartForce,
			Rage = orkConfig.StartRage
		};
		
		Debug.Log($"Force: {_characteristics.Force}, Rage: {_characteristics.Rage}, Health: {_health.Value}");
	}
	
	private class OrkСharacteristic
	{
		public int Force { get; set; }
		public int Rage { get; set; }
	}
}