using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
	public float Sensitivity
	{
		get { return sensitivity; }
		set { sensitivity = value; }
	}

	[Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
	[Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;
	[SerializeField] Camera _camera;

	Vector2 rotation = Vector2.zero;

	const string xAxis = "Mouse X";
	const string yAxis = "Mouse Y";

	void Update()
	{
		rotation.x += Input.GetAxis(xAxis) * sensitivity;
		rotation.y += Input.GetAxis(yAxis) * sensitivity;
		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		_camera.transform.localRotation = xQuat * yQuat; 
	}
}
