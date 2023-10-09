using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.InputSystem.DefaultInputActions;

public class controller_Player : MonoBehaviour
{
	#region Constants Region
	const string _HORIZONTAL = "Horizontal";
	const string _VERTICAL = "Vertical";
	const string _LOOK_X = "Look X";
	const string _LOOK_Y = "Look Y";
	#endregion

	public base_Player _player;

	public Camera _camera;
	public Rigidbody _rb;

	public Player_InputActiona playerActions;
	public InputAction move;
	public InputAction look;

	float axis_Y;
	float axis_X;

	private void OnEnable()
	{
		_player.ResetPlayer();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		Player_Camera();
	}

	private void FixedUpdate()
	{
		Player_Movement();
	}

	private void Player_Movement()
	{
		Vector2 axis = new Vector2(Input.GetAxis(_VERTICAL), Input.GetAxis(_HORIZONTAL)) * _player._moveSpeed;
		Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0, Camera.main.transform.right.x);
		
		Vector3 newDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * (_rb.velocity.y));
		_rb.velocity = newDirection;
	}

	private void Player_Camera()
	{
		axis_Y -= (Input.GetAxisRaw(_LOOK_Y) * Time.deltaTime * _player._sensitivity) * 100;
		axis_Y = Mathf.Clamp(axis_Y, -88, 88);

		axis_X += (Input.GetAxisRaw(_LOOK_X) * Time.deltaTime * _player._sensitivity) * 100;

		_camera.transform.localRotation = Quaternion.Euler(axis_Y, axis_X, 0);
	}
}
