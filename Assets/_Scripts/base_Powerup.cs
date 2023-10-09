using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Base/Powerup")]
public class base_Powerup : base_Enitity
{
	public string _name;
	public string _description;

	public int _duration;
	public int _cooldown; //optional

	public Sprite _icon;

}
