using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour {
	Controls _controls = null;
	Vector2 _moveAxis;

	void Awake() {
		_controls = new Controls();
		_controls.Player.Interact.performed += TestInteraction;
		_controls.Player.Movement.performed += TestAxis;
		_controls.Player.Enable();
	}

	void TestInteraction(InputAction.CallbackContext context) {
		Debug.Log("Interacted");
	}

	void TestAxis(InputAction.CallbackContext context) {
		_moveAxis = context.ReadValue<Vector2>();
		Debug.Log("Movement: " + _moveAxis);
	}
}
