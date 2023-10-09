using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickup", menuName = "Base/Pickup")]
public class base_Pickup : base_Enitity
{
	public string _name;
	public string _description;

	public Sprite _icon;

	public enum Type { ammo, health};
	public Type _type;

}
