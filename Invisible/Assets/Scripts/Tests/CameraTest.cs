using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTest : MonoBehaviour {
	Controls _controls;
	[SerializeField] Camera _cam1 = null;
	[SerializeField] Camera _cam2 = null;

	void Awake() {
		_controls = new Controls();
		_controls.Player.Interact.performed += Switch;
		_controls.Player.Enable();
	}

	void Switch(InputAction.CallbackContext context) {
		_cam1.enabled = !_cam1.enabled;
		_cam2.enabled = !_cam2.enabled;
	}
}
