using System;
using UnityEngine;

public class DragonEnemy : Enemy
{
	private DragonСharacteristic _characteristics;
	
	public override void Initialize(BaseEnemyConfig config)
	{
		if (config is DragonEnemyConfig dragonConfig == false)
		{
			throw new ArgumentException($"Not valid config. {typeof(DragonEnemyConfig)} is expected");
		}
		
		base.Initialize(dragonConfig);

		_characteristics = new DragonСharacteristic
		{
			FireDamage = dragonConfig.FireDamage,
			FireRange = dragonConfig.FireRange
		};
		
		Debug.Log($"Fire Damage: {_characteristics.FireDamage}, Fire Range: {_characteristics.FireRange}, Health: {_health.Value}");
	}

	private class DragonСharacteristic
	{
		public int FireDamage { get; set; }
		public int FireRange { get; set; }
	}
}