using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/Gameplay/Configs/EnemyConfig")]
public class EnemyConfigs : ScriptableObject
{
	[SerializeField] private List<OrkEnemyConfig> _orkEnemies;
	[SerializeField] private List<ElfEnemyConfig> _elfEnemies;
	[SerializeField] private List<DragonEnemyConfig> _dragonEnemies;
	
	[SerializeField] private EnemyViewConfig _orkEnemyViewConfig;
	[SerializeField] private EnemyViewConfig _elfEnemyViewConfig;
	[SerializeField] private EnemyViewConfig _dragonEnemyViewConfig;
	
	public IReadOnlyList<OrkEnemyConfig> OrkEnemies => _orkEnemies;
	public IReadOnlyList<ElfEnemyConfig>  ElfEnemies => _elfEnemies;
	public IReadOnlyList<DragonEnemyConfig>  DragonEnemies => _dragonEnemies;
	
	public EnemyViewConfig OrkEnemyViewConfig => _orkEnemyViewConfig;
	public EnemyViewConfig ElfEnemyViewConfig => _elfEnemyViewConfig;
	public EnemyViewConfig DragonEnemyViewConfig => _dragonEnemyViewConfig;
}