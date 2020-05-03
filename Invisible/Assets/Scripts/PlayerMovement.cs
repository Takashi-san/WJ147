using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] PlayerData _playerData = null;
	[SerializeField] TransitionData _transitionData = null;
	float _speed;
	Rigidbody2D _rb;
	Controls _controls;
	Vector2 _movement;
	bool _forcedMovement = false;

	void Awake() {
		_speed = _playerData.speed;
		_rb = GetComponent<Rigidbody2D>();
		_controls = new Controls();
		_controls.Player.Enable();

		switch (_transitionData.direction) {
			case TransitionData.Direction.Up:
				transform.position = _playerData.spawnUp;
				Move(PlayerData.Direction.Down, _playerData.spawnWalkTime);
				break;

			case TransitionData.Direction.Down:
				transform.position = _playerData.spawnDown;
				Move(PlayerData.Direction.Up, _playerData.spawnWalkTime);
				break;

			case TransitionData.Direction.Left:
				transform.position = _playerData.spawnLeft;
				Move(PlayerData.Direction.Right, _playerData.spawnWalkTime);
				break;

			case TransitionData.Direction.Right:
				transform.position = _playerData.spawnRight;
				Move(PlayerData.Direction.Left, _playerData.spawnWalkTime);
				break;

			default:
				break;
		}
	}

	void Update() {
		if (!_forcedMovement) {
			_movement = _controls.Player.Movement.ReadValue<Vector2>();
		}
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

	public void Move(PlayerData.Direction direction, float time) {
		switch (direction) {
			case PlayerData.Direction.Up:
				_movement = Vector2.up;
				break;

			case PlayerData.Direction.Down:
				_movement = Vector2.down;
				break;

			case PlayerData.Direction.Left:
				_movement = Vector2.left;
				break;

			case PlayerData.Direction.Right:
				_movement = Vector2.right;
				break;

			default:
				_movement = Vector2.zero;
				break;
		}
		StartCoroutine(MoveTimer(time));
	}

	IEnumerator MoveTimer(float time) {
		LockMovement();
		yield return new WaitForSeconds(time);
		UnlockMovement();
		yield break;
	}

	public void LockMovement() {
		_controls.Player.Disable();
		_forcedMovement = true;
	}

	public void UnlockMovement() {
		_controls.Player.Enable();
		_forcedMovement = false;
	}
}
