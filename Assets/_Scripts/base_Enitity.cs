using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Entity", menuName = "Base/Entity")]
public class base_Enitity : ScriptableObject
{
	[Custom_Property_ID]
	public string Id;

	[HideInInspector] 
	public GameObject _gameobject;
}
