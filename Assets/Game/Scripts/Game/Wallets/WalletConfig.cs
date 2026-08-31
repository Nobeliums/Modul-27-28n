using UnityEngine;

public class WalletConfig : MonoBehaviour // Вообще я бы сделал этот класс как ScriptableObject, но мы пока его не прошли по-этому пусть будет монобехом, а передаваться будет в виде префаба 
{
	[SerializeField] private string _name;
	[SerializeField] private int _startValue;
	[SerializeField] private Sprite _sprite;
	[SerializeField] private WalletType _type;

	public string Name => _name;
	public int StartValue => _startValue;
	public Sprite Sprite => _sprite;
	public WalletType Type => _type;
}