using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Enemy _enemyPrefab;

	[SerializeField] private TimerService _timerService;
	[SerializeField] private DestroyerService _destroyeblesContainer;

	[SerializeField] private List<Transform> _spawnPoint;
	[SerializeField] private List<ConditionType> _conditions;

	[SerializeField] private int _maxDestroyebleInContainer;
	
	private List<Enemy> _spawnedEnemies;

	public void Initialize()
	{
		_spawnedEnemies = new List<Enemy>();
	}

	public void SpawnNewEnemy()
	{
		int randomSpawnIndex = UnityEngine.Random.Range(0, _spawnPoint.Count);

		Enemy spawnedEnemy = Instantiate(_enemyPrefab, _spawnPoint[randomSpawnIndex].position, Quaternion.identity);
		spawnedEnemy.Destroyed += OnEnemyDestroyed;

		_spawnedEnemies.Add(spawnedEnemy);

		int conditionsCount = UnityEngine.Random.Range(1, _conditions.Count + 1);
		
		List<ConditionType> possibleConditions = new  List<ConditionType>(_conditions);

		for (int i = conditionsCount; i > 0; i--)
		{
			int randomIndex = UnityEngine.Random.Range(0, possibleConditions.Count);
			ConditionType conditionType = possibleConditions[randomIndex];

			Func<bool> condition = GetConditionBy(conditionType, spawnedEnemy);

			possibleConditions.RemoveAt(randomIndex);

			if (condition == null)
				continue;

			_destroyeblesContainer.Registry(spawnedEnemy, condition);
			
			Debug.Log($"Зарегистрирован {conditionType} у {spawnedEnemy.name}");
		}
	}

	private Func<bool> GetConditionBy(ConditionType type, Enemy enemy)
	{
		switch (type)
		{
			case  ConditionType.Dead:
				return () => enemy.IsDead;
			case  ConditionType.TimerFinished:
				return GetTimerCondition(enemy);
			case  ConditionType.ContainerOverflow:
				return GetContainerOverflowCondition();
			default:
				Debug.LogError("Unknown condition type: " + type + $" In {nameof(GetConditionBy)}");
				return null;
		}
	}

	private Func<bool> GetContainerOverflowCondition()
	{
		return () => _spawnedEnemies.Count > _maxDestroyebleInContainer;
	}
	
	private Func<bool> GetTimerCondition(Enemy enemy)
	{
		Timer timer = _timerService.CreateTimer(10);
		
		TimerWatcher watcher = new TimerWatcher(timer);
		_timerService.StartTimer(timer);
		
		enemy.Destroyed += (enemy) => _timerService.StopTimer(timer);
		
		return watcher.IsTimerFinished;
	}

	private void OnEnemyDestroyed(Enemy enemy)
	{
		_spawnedEnemies.Remove(enemy);
		enemy.Destroyed -= OnEnemyDestroyed;
	}

	private enum ConditionType
	{
		Dead,
		TimerFinished,
		ContainerOverflow
	}
}