using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConfigService : MonoBehaviour
{
	[SerializeField] private EnemyConfigs _configs;

	public OrkEnemyConfig GetRandomOrkEnemyConfig() => GetConfig(_configs.OrkEnemies);

	public ElfEnemyConfig GetRandomElfEnemyConfig() => GetConfig(_configs.ElfEnemies);

	public DragonEnemyConfig GetRandomDragonEnemyConfig() => GetConfig(_configs.DragonEnemies);

	public EnemyViewConfig GetEnemyViewConfigFor(BaseEnemyConfig enemyConfig)
	{
		switch (enemyConfig)
		{
			case OrkEnemyConfig:
				return _configs.OrkEnemyViewConfig;
			case ElfEnemyConfig:
				return _configs.ElfEnemyViewConfig;
			case DragonEnemyConfig:
				return _configs.DragonEnemyViewConfig;
			default:
				throw new ArgumentException($"{enemyConfig.GetType().Name} is not supported");
		}
	}

	private T GetConfig<T>(IReadOnlyList<T> configs) where T : BaseEnemyConfig
	{
		int randomIndex = Random.Range(0, configs.Count);

		return configs[randomIndex];
	}
}