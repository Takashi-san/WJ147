﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] PlayerData _playerData = null;
	[SerializeField] TransitionData _transitionData = null;
	Animator _animator;
	float _speed;
	Rigidbody2D _rb;
	Controls _controls;
	Vector2 _movement;
	Vector2 _lastMovement = Vector2.zero;
	bool _forcedMovement = false;

	void Awake() {
		_speed = _playerData.speed;
		_rb = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
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

		// Animator: 0 = right, 1 = left, 2 = down, 3 = up.
		if (_movement.x != 0) {
			if (_movement.x > 0) {
				_animator.SetInteger("Direction", 0);
			}
			else {
				_animator.SetInteger("Direction", 1);
			}
			_animator.SetBool("Moving", true);

			target = (Vector2)transform.position + Vector2.right * (_movement.x * _speed * Time.fixedDeltaTime);
			_rb.MovePosition(target);
		}
		else if (_movement.y != 0) {
			if (_movement.y > 0) {
				_animator.SetInteger("Direction", 3);
			}
			else {
				_animator.SetInteger("Direction", 2);
			}
			_animator.SetBool("Moving", true);

			target = (Vector2)transform.position + Vector2.up * (_movement.y * _speed * Time.fixedDeltaTime);
			_rb.MovePosition(target);
		}
		else {
			_animator.SetBool("Moving", false);
		}

		if (_movement != _lastMovement) {
			_animator.SetTrigger("Update");
			_lastMovement = _movement;
		}
	}

	public void Move(PlayerData.Direction direction, float time) {
		LockMovement();
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
		yield return new WaitForSeconds(time);
		UnlockMovement();
		yield break;
	}

	public void LockMovement() {
		_controls.Player.Disable();
		_movement = Vector2.zero;
		_forcedMovement = true;
	}

	public void UnlockMovement() {
		_controls.Player.Enable();
		_forcedMovement = false;
	}
}
