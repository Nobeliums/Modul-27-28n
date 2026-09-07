using System.Collections.Generic;
using UnityEngine;

public class ConfigService : MonoBehaviour
{
	[SerializeField] private EnemyConfigs _configs;

	public OrkEnemyConfig GetRandomOrkEnemyConfig() => GetConfig(_configs.OrkEnemies);

	public ElfEnemyConfig GetRandomElfEnemyConfig() => GetConfig(_configs.ElfEnemies);

	public DragonEnemyConfig GetRandomDragonEnemyConfig() => GetConfig(_configs.DragonEnemies);

	private T GetConfig<T>(IReadOnlyList<T> configs) where T : BaseEnemyConfig
	{
		int randomIndex = Random.Range(0, configs.Count);
		Debug.Log(configs[randomIndex]);
		return configs[randomIndex];
	}
}