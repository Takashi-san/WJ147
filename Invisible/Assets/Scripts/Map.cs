using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Map : MonoBehaviour {
	Controls _controls;

	void Start() {
		FindObjectOfType<PlayerMovement>().LockMovement();
		_controls = new Controls();
		_controls.Player.Interact.performed += Close;
		_controls.Player.Enable();
	}

	void Close(InputAction.CallbackContext context) {
		Destroy(gameObject);
	}

	void OnDisable() {
		FindObjectOfType<PlayerMovement>().UnlockMovement();
		_controls.Player.Interact.performed -= Close;
	}
}
