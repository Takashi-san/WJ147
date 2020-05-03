using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] [Min(0)] float _speed = 0;
	Rigidbody2D _rb;
	Controls _controls;
	Vector2 _movement;

	void Awake() {
		_rb = GetComponent<Rigidbody2D>();
		_controls = new Controls();
		_controls.Player.Enable();
	}

	void Update() {
		_movement = _controls.Player.Movement.ReadValue<Vector2>();
	}

	void FixedUpdate() {
		Vector2 target;

		if (_movement.x != 0) {
			target = (Vector2)transform.position + Vector2.right * (_movement.x * _speed * Time.fixedDeltaTime);
			_rb.MovePosition(target);
		}
		else if (_movement.y != 0) {
			target = (Vector2)transform.position + Vector2.up * (_movement.y * _speed * Time.fixedDeltaTime);
			_rb.MovePosition(target);
		}
	}
}
