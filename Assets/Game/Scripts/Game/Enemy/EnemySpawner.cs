using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private TimerService _timerService;
	[SerializeField] private DestroyerService _destroyeblesContainer;

	[SerializeField] private List<Transform> _spawnPoint;
	[SerializeField] private List<DieConditionType> _conditions;

	[SerializeField] private int _maxEnemyCount;
	[SerializeField] private int _aliveTime;
	
	private List<Enemy> _spawnedEnemies;

	public void Initialize()
	{
		_spawnedEnemies = new List<Enemy>();
	}

	public void SpawnEnemyWithRandomConditions(BaseEnemyConfig config)
	{
		Enemy spawnedEnemy = CreateEnemy(config);

		int conditionsCount = UnityEngine.Random.Range(0, _conditions.Count);
		
		List<DieConditionType> currentPossibleConditions = new  List<DieConditionType>(_conditions);

		for (int i = 0; i <= conditionsCount; i++)
		{
			int randomIndex = UnityEngine.Random.Range(0, currentPossibleConditions.Count);
			DieConditionType dieConditionType = currentPossibleConditions[randomIndex];

			Func<bool> condition = GetConditionBy(dieConditionType, spawnedEnemy);

			currentPossibleConditions.RemoveAt(randomIndex);

			if (condition == null)
				continue;

			_destroyeblesContainer.Registry(spawnedEnemy, condition);
		}
	}

	public void SpawnEnemyWith(DieConditionType conditionType, BaseEnemyConfig config, EnemyViewConfig viewConfig)
	{
		Enemy spawnedEnemy = CreateEnemy(config);

		spawnedEnemy.GetComponentInChildren<EnemyView>().SetSprite(viewConfig.View);
		
		Func<bool> condition = GetConditionBy(conditionType, spawnedEnemy);
		
		_destroyeblesContainer.Registry(spawnedEnemy, condition);
	}

	private Enemy CreateEnemy(BaseEnemyConfig config)
	{
		int randomSpawnIndex = UnityEngine.Random.Range(0, _spawnPoint.Count);

		Enemy spawnedEnemy = Instantiate(config.EnemyPrefab, _spawnPoint[randomSpawnIndex].position, Quaternion.identity);
		spawnedEnemy.Initialize(config);

		spawnedEnemy.Destroyed += OnEnemyDestroyed;

		_spawnedEnemies.Add(spawnedEnemy);

		return spawnedEnemy;
	}

	private Func<bool> GetConditionBy(DieConditionType type, Enemy enemy)
	{
		switch (type)
		{
			case  DieConditionType.Dead:
				return () => enemy.IsDead;
			case  DieConditionType.TimerFinished:
				return GetTimerCondition(enemy);
			case  DieConditionType.CountOverflow:
				return GetContainerOverflowCondition();
			default:
				Debug.LogError("Unknown condition type: " + type + $" In {nameof(GetConditionBy)}");
				return null;
		}
	}

	private Func<bool> GetContainerOverflowCondition()
	{
		return () => _spawnedEnemies.Count > _maxEnemyCount;
	}
	
	private Func<bool> GetTimerCondition(Enemy enemy)
	{
		Timer timer = _timerService.CreateTimer(_aliveTime);
		
		TimerWatcher watcher = new TimerWatcher(timer);
		timer.StartTimer();
		
		enemy.Destroyed += (enemy) => timer.StopTimer();
		
		return watcher.IsTimerFinished;
	}

	private void OnEnemyDestroyed(Enemy enemy)
	{
		_spawnedEnemies.Remove(enemy);
		enemy.Destroyed -= OnEnemyDestroyed;
	}
}