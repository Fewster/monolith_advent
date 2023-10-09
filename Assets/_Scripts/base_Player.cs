using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Base/Player")]
public class base_Player : base_Enitity
{
	[HideInInspector] public int _health;
	[HideInInspector] public int _shield;
	[HideInInspector] public int _stamina;

	[HideInInspector] public float _moveSpeed;
	[HideInInspector] public float _jumpForce;

	// Player Settings
	[HideInInspector] public float _sensitivity;

	[HideInInspector] public GameObject _gameobject;

	[SerializeField] int default_health = 100;
	[SerializeField] int default_shield = 0;
	[SerializeField] int default_stamina = 100;

	[SerializeField] float default_sensitivity = 5.0f;

	[SerializeField] float default_moveSpeed = 5.0f;
	[SerializeField] float default_jumpForce = 6.0f;

	public void ResetPlayer()
	{
		_health = default_health; 
		_shield = default_shield; 
		_stamina = default_stamina;

		_sensitivity = default_sensitivity;

		_moveSpeed	= default_moveSpeed;
		_jumpForce = default_jumpForce;
	}
}
