using UnityEngine;

public class UiService : MonoBehaviour
{
	[SerializeField] private RectTransform _walletGrid;
	
	[SerializeField] private WalletView _walletViewPrefab;
	[SerializeField] private WalletService _walletService;

	public void Initialize()
	{
		CreateWalletViewGrid();
	}

	private void CreateWalletViewGrid()
	{
		foreach (var walletConfig in _walletService.WalletConfigs)
		{
			WalletView _view = Instantiate(_walletViewPrefab, _walletGrid);
			
			_view.Initialize(_walletService,  walletConfig);
		}
	}
}