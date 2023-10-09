using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{
	public base_Player player;

	Vector3 _CAMERA_POS = new Vector3(0, 0.8f, 0);

	const string _HORIZONTAL = "Horizontal";
	const string _VERTICAL = "Vertical";
	const string _LOOK_X = "Look X";
	const string _LOOK_Y = "Look Y";

	private Rigidbody _rb;
	private CapsuleCollider _collider;

	private float _yaw, _pitch, _move_speed, _jump_force;
	private bool _crouched = false, _running = false, _grounded = false;

	public Camera _camera;

	private float _stamina = 200;
	public float Stamina
	{
		get => _stamina;
		set => _stamina = value;
	}

	[SerializeField] private float _sensitivity;
	public float Sensitivity 
	{ 
		get => _sensitivity;
		set => _sensitivity = value;
	}
	
	private void Start()
	{
		UnityEngine.Cursor.lockState = CursorLockMode.Locked;
		UnityEngine.Cursor.visible = false;

		_rb = gameObject.GetComponent<Rigidbody>();
		_collider = GetComponent<CapsuleCollider>();

		Debug.Log($"Player ID: {player.Id}, Health: {player._health}, Stamina: {player._stamina}, Shield: {player._shield}");
		player.ResetPlayer();
		Debug.Log($"Player ID: {player.Id}, Health: {player._health}, Stamina: {player._stamina}, Shield: {player._shield}");
	}

	private void Update()
	{


		RaycastHit hit;

		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		_pitch -= Input.GetAxisRaw(_LOOK_Y) * _sensitivity;
		_pitch = Mathf.Clamp(_pitch, -88, 88);

		_yaw += Input.GetAxisRaw(_LOOK_X) * _sensitivity;

		_camera.transform.localRotation = Quaternion.Euler(_pitch, _yaw, 0);

		if(Physics.Raycast(_rb.transform.position, _rb.transform.TransformDirection(Vector3.down), out hit, 1, layerMask))
		{
			// Jump while on ground
			if (Input.GetKey(KeyCode.Space) && !_crouched)
			{
				Player_Jumping(6.0f);
			}

			// Run while on ground and not crouched
			if (Input.GetKey(KeyCode.LeftShift) && !_crouched && _stamina > 0)
			{
				_move_speed = 12f;
				Stamina_Reduce(2);
			}
			else if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				_move_speed = 5f;
				StaminaRegen(20);
			}

			if (Input.GetKey(KeyCode.LeftControl)) 
			{
				Player_Crouching(true, 1.12f, -0.4f, 0.5f);
				_move_speed = 1.5f;
			}
			else if (Input.GetKeyUp(KeyCode.LeftControl))
			{
				Player_Crouching(false, 1.9f, -0.0f, 1.8f);
				_move_speed = 5f;
			}
		}
		else // If not on floor walking is allowed for forward movement
		{
			_move_speed = 5f;
		}

		// crouch on the floor
		//Debug.Log($"debug: {_stamina}");
	}

	private void FixedUpdate()
	{
		Player_Movement();
	}

	private void Player_Movement()
	{
		Vector2 axis = new Vector2(Input.GetAxis(_VERTICAL), Input.GetAxis(_HORIZONTAL)) * _move_speed;

		Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0, Camera.main.transform.right.x);
		Vector3 newDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * _rb.velocity.y);

		_rb.MovePosition(newDirection);
	}

	private void Player_Jumping(float _jump_force) 
	{
		Debug.DrawRay(_rb.transform.position, _rb.transform.TransformDirection(Vector3.down), Color.red, 1);

		_grounded = false;
		_rb.velocity = new Vector3(_rb.velocity.x, _jump_force, _rb.velocity.z);
	}

	private void Player_Crouching(bool crouched, float col_height, float center_y, float cam_height)
	{
		_crouched = crouched;
		_collider.height = col_height;
		_collider.center = new Vector3(0, center_y, 0);

		_camera.transform.position = new Vector3(_camera.transform.position.x, cam_height, _camera.transform.position.z);
	}

	private void Stamina_Reduce(float amount)
	{
		_running = true;
		if(_stamina >= 0)
		{
			_stamina -= amount;
		}
	}

	private void StaminaRegen(float amount)
	{
		_running = false;
		if (_stamina <= 200)
		{
			_stamina += amount;
		}
	}
}
