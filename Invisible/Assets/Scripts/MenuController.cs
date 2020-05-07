using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour {
	[SerializeField] GameObject _menu = null;
	Controls _controls;

	void Start() {
		if (!_menu) {
			Debug.LogWarning("No Menu specified to control");
		}
		else {
			_menu.SetActive(false);
		}

		_controls = new Controls();
		_controls.Player.Pause.performed += Paused;
		_controls.Player.Enable();
	}

	void Paused(InputAction.CallbackContext context) {
		if (_menu.activeInHierarchy) {
			Deactivate();
		}
		else {
			Activate();
		}
	}

	void OnDestroy() {
		Time.timeScale = 1;
		_controls.Player.Pause.performed -= Paused;
	}

	public void Activate() {
		_menu.SetActive(true);
		Time.timeScale = 0;
	}

	public void Deactivate() {
		_menu.SetActive(false);
		Time.timeScale = 1;
	}
}
