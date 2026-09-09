using UnityEngine;

public class CurrencyConfig : MonoBehaviour // Вообще я бы сделал этот класс как ScriptableObject, но мы пока его не прошли по-этому пусть будет монобехом, а передаваться будет в виде префаба 
{
	[SerializeField] private string _name;
	[SerializeField] private int _startValue;
	[SerializeField] private Sprite _sprite;
	[SerializeField] private CurrencyType _type;

	public string Name => _name;
	public int StartValue => _startValue;
	public Sprite Sprite => _sprite;
	public CurrencyType Type => _type;
}