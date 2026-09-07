using System;
using UnityEngine;

public class ElfEnemy : Enemy
{
	private ElfСharacteristic _characteristics;

	public override void Initialize(BaseEnemyConfig config)
	{
		if (config is ElfEnemyConfig elfConfig == false)
		{
			throw new ArgumentException($"Not valid config. {typeof(ElfEnemyConfig)} is expected");
		}

		base.Initialize(config);

		_characteristics = new ElfСharacteristic
		{
			Magic = elfConfig.StartMagic,
			Mana = elfConfig.StartMana
		};
		
		Debug.Log($"Mana: {_characteristics.Mana}, Magic: {_characteristics.Magic}, Health: {_health.Value}");
	}

	private class ElfСharacteristic
	{
		public int Mana { get; set; }
		public int Magic { get; set; }
	}
}