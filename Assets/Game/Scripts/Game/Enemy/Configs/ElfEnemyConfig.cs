using System;
using UnityEngine;

[Serializable]
public class ElfEnemyConfig : BaseEnemyConfig
{
	[SerializeField] private int _startMana;
	[SerializeField] private int _startMagic;
	
	public int StartMana => _startMana;
	public int StartMagic => _startMagic;
}