using System.Collections.Generic;
using UnityEngine;

public class EnemyConfigs : MonoBehaviour
{
	[SerializeField] private List<OrkEnemyConfig> _orkEnemies;
	[SerializeField] private List<ElfEnemyConfig> _elfEnemies;
	[SerializeField] private List<DragonEnemyConfig> _dragonEnemies;
	
	public IReadOnlyList<OrkEnemyConfig> OrkEnemies => _orkEnemies;
	public IReadOnlyList<ElfEnemyConfig>  ElfEnemies => _elfEnemies;
	public IReadOnlyList<DragonEnemyConfig>  DragonEnemies => _dragonEnemies;
	
	
}