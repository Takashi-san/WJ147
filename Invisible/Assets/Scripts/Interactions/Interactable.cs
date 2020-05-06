using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class Interactable : MonoBehaviour {
	[SerializeField] Interactions _interaction = null;
	[SerializeField] GameObject _icon = null;
	Controls _controls;
	bool _active = true;
	bool _range = false;
	Action _callback;

	void Start() {
		_controls = new Controls();
		_controls.Player.Interact.performed += Interacted;
		_controls.Player.Enable();
		_callback += FinishedCallBack;
		if (_icon) {
			_icon.SetActive(false);
		}

		_interaction.Setup();
	}

	void Interacted(InputAction.CallbackContext context) {
		if (_range) {
			if (_active) {
				_active = false;
				if (_icon) {
					_icon.SetActive(false);
				}
				_interaction.Interaction(_callback);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			_range = true;
			if (_active && _icon) {
				_icon.SetActive(true);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			_range = false;
			if (_icon) {
				_icon.SetActive(false);
			}
		}
	}

	void FinishedCallBack() {
		_active = true;
		if (_range && _icon) {
			_icon.SetActive(true);
		}
	}
}
