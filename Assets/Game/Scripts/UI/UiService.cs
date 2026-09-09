using System;
using UnityEngine;

public class UiService : MonoBehaviour
{
	[SerializeField] private RectTransform _walletGrid;
	[SerializeField] private RectTransform _timerGrid;
	
	[SerializeField] private CurrencyValueView currencyValueViewPrefab;
	[SerializeField] private TimerSliderView _timerSliderViewPrefab;
	[SerializeField] private TimerIconsView _timerIconsViewPrefab;

	[SerializeField] private TimerService _timerService;
	[SerializeField] private TimerViewType _timerViewType;

	private Wallet _wallet;
	
	private TimerView _currentTimerView;

	public void Initialize(Wallet wallet)
	{
		_wallet = wallet;

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
	}

	private void OnDestroy()
	{
		_timerService.TimerCreated -= CreateTimerView;
	}

	private void CreateWalletViewGrid()
	{
		foreach (var currencyConfig in _wallet.CurrencyConfigs)
		{
			CurrencyValueView _view = Instantiate(currencyValueViewPrefab, _walletGrid);
			
			_view.Initialize(_wallet.GetCurrencyValueBy(currencyConfig.Type),  currencyConfig);
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