using System;
using UnityEngine;

public class UiService : MonoBehaviour
{
	[SerializeField] private RectTransform _walletGrid;
	[SerializeField] private RectTransform _timerGrid;
	
	[SerializeField] private WalletView _walletViewPrefab;
	[SerializeField] private TimerSliderView _timerSliderViewPrefab;
	[SerializeField] private TimerIconsView _timerIconsViewPrefab;

	[SerializeField] private WalletService _walletService;
	[SerializeField] private TimerService _timerService;
	
	[SerializeField] private TimerViewType _timerViewType;
	
	private TimerView _currentTimerView;

	public void Initialize()
	{
		CreateWalletViewGrid();
		_timerService.TimerCreated += CreateTimerView;

		switch (_timerViewType)
		{
			case TimerViewType.Slider:
				_currentTimerView = _timerSliderViewPrefab;
				break;
			case TimerViewType.Icons:
				_currentTimerView = _timerIconsViewPrefab;
				break;
		}
	}

	public void SwitchTimerViewType()
	{
		switch (_timerViewType)
		{
			case TimerViewType.Slider:
				_timerViewType = TimerViewType.Icons;
				_currentTimerView = _timerIconsViewPrefab;
				break;
			
			case TimerViewType.Icons:
				_timerViewType = TimerViewType.Slider;
				_currentTimerView = _timerSliderViewPrefab;
				break;
		}
		
		Debug.Log(_timerViewType);
		Debug.Log(_currentTimerView.name);
	}

	private void OnDestroy()
	{
		_timerService.TimerCreated -= CreateTimerView;
	}

	private void CreateWalletViewGrid()
	{
		foreach (var walletConfig in _walletService.WalletConfigs)
		{
			WalletView _view = Instantiate(_walletViewPrefab, _walletGrid);
			
			_view.Initialize(_walletService,  walletConfig);
		}
	}

	private void CreateTimerView(Timer timer)
	{
		TimerView timerSliderView = Instantiate(_currentTimerView, _timerGrid);
		timerSliderView.Initialize(timer);
	}

	private enum TimerViewType
	{
		Slider,
		Icons
	}
}