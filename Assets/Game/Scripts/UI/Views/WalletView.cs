using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletView  : MonoBehaviour
{
	[SerializeField] private TMP_Text _walletValue;
	[SerializeField] private Image _walletImage;

	private WalletService _walletService;
	private WalletConfig _walletConfig;
	
	public void Initialize(WalletService walletService, WalletConfig walletConfig)
	{
		_walletService = walletService;
		_walletConfig = walletConfig;
		_walletImage.sprite = _walletConfig.Sprite;
		_walletValue.text = _walletConfig.StartValue.ToString();

		if (_walletService.TryAddListenerTo(_walletConfig.Type, OnValueChanged) == false)
		{
			Debug.LogError($"Type {_walletConfig.Type} was already created");
			
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{
		_walletService.TryRemoveListenerFrom(_walletConfig.Type, OnValueChanged);
	}

	private void OnValueChanged(int newValue)
	{
		_walletValue.text = newValue.ToString();
	}
}