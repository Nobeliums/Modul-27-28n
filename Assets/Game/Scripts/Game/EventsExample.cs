using UnityEngine;

public class EventsExample : MonoBehaviour
{
	private const KeyCode AddCoinKey = KeyCode.Q;
	private const KeyCode AddDiamondKey = KeyCode.W;
	private const KeyCode AddEnergyKey = KeyCode.E;
	private const KeyCode RemoveCoinKey = KeyCode.R;
	private const KeyCode RemoveDiamondKey = KeyCode.T;
	private const KeyCode RemoveEnergyKey = KeyCode.Y;
	
	private const KeyCode CreateNewTimerKey = KeyCode.A;
	private const KeyCode StartAllTimersKey = KeyCode.S;
	private const KeyCode StopAllTimersKey = KeyCode.D;
	private const KeyCode SwitchTimerViewTypeKey = KeyCode.F;
	
	private const KeyCode SpawnDragonEnemyWithRandomConfigKey = KeyCode.Z;
	private const KeyCode SpawnOrkEnemyWithRandomConfigKey = KeyCode.X;
	private const KeyCode SpawnElfEnemyWithRandomConfigKey =  KeyCode.C;
	
	[SerializeField] private WalletService _walletService;
	[SerializeField] private TimerService _timerService;
	[SerializeField] private UiService _uiService;
	[SerializeField] private EnemySpawner _enemySpawner;
	[SerializeField] private ConfigService _configService;

	[SerializeField] private int _minRandomTime;
	[SerializeField] private int _maxRandomTime;

	private void Update()
	{
		if (Input.GetKeyDown(AddCoinKey))
			_walletService.AddValueTo(WalletType.Coin, 1);
		
		if (Input.GetKeyDown(AddDiamondKey))
			_walletService.AddValueTo(WalletType.Diamond, 1);
		
		if (Input.GetKeyDown(AddEnergyKey))
			_walletService.AddValueTo(WalletType.Energy, 1);
		
		if (Input.GetKeyDown(RemoveCoinKey))
			_walletService.RemoveValueFrom(WalletType.Coin, 1);

		if (Input.GetKeyDown(RemoveDiamondKey))
			_walletService.RemoveValueFrom(WalletType.Diamond, 1);

		if (Input.GetKeyDown(RemoveEnergyKey))
			_walletService.RemoveValueFrom(WalletType.Energy, 1);

		if (Input.GetKeyDown(CreateNewTimerKey))
			_timerService.CreateTimer(Random.Range(_minRandomTime, _maxRandomTime));
		
		if (Input.GetKeyDown(StartAllTimersKey))
			_timerService.StartAllTimers();
		
		if (Input.GetKeyDown(StopAllTimersKey))
			_timerService.StopAllTimers();
		
		if (Input.GetKeyDown(SwitchTimerViewTypeKey))
			_uiService.SwitchTimerViewType();

		if (Input.GetKeyDown(SpawnDragonEnemyWithRandomConfigKey))
		{
			BaseEnemyConfig config = _configService.GetRandomDragonEnemyConfig();
			_enemySpawner.SpawnEnemyWith(DieConditionType.Dead, config);
		}

		if (Input.GetKeyDown(SpawnOrkEnemyWithRandomConfigKey))
		{
			BaseEnemyConfig config = _configService.GetRandomOrkEnemyConfig();
			_enemySpawner.SpawnEnemyWith(DieConditionType.Dead, config);
		}

		if (Input.GetKeyDown(SpawnElfEnemyWithRandomConfigKey))
		{
			BaseEnemyConfig config = _configService.GetRandomElfEnemyConfig();
			_enemySpawner.SpawnEnemyWith(DieConditionType.Dead,  config);
		}

	}
}