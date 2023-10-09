using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon", menuName = "Base/Weapon")]
public class base_Weapon : base_Enitity
{
	public string _name;
	public string _description;

	public int _damage;
	public int _maxAmmo;

	public float _fireRate;
	public enum Type { energy, ballistic, kinetic, none};
	public Type _type;

	public Sprite _icon;
	public GameObject _bulletSpawn;
	
	//TODO
	// Mods
	// Quality
	// Repair
}
