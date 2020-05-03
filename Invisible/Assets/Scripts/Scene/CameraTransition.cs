using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {
	[SerializeField] TransitionData _transitionData = null;
	SceneHandler _sceneHandler;
	bool _doTransition = false;
	bool _doEntrance = false;
	Vector3 _initPosition;
	Vector3 _finalPosition;
	float _timer = 0;
	string _scene;

	void Awake() {
		_doEntrance = true;
		switch (_transitionData.direction) {
			case TransitionData.Direction.Up:
				transform.position = _transitionData.camUp;
				break;

			case TransitionData.Direction.Down:
				transform.position = _transitionData.camDown;
				break;

			case TransitionData.Direction.Left:
				transform.position = _transitionData.camLeft;
				break;

			case TransitionData.Direction.Right:
				transform.position = _transitionData.camRight;
				break;

			default:
				_doEntrance = false;
				break;
		}
		_initPosition = transform.position;
	}

	void Start() {
		_sceneHandler = FindObjectOfType<SceneHandler>();
	}

	public void DoTransition(TransitionData.Direction direction, string scene) {
		_doTransition = true;
		_scene = scene;
		_initPosition = transform.position;

		switch (direction) {
			case TransitionData.Direction.Up:
				_finalPosition = _transitionData.camUp;
				_transitionData.direction = TransitionData.Direction.Down;
				break;

			case TransitionData.Direction.Down:
				_finalPosition = _transitionData.camDown;
				_transitionData.direction = TransitionData.Direction.Up;
				break;

			case TransitionData.Direction.Left:
				_finalPosition = _transitionData.camLeft;
				_transitionData.direction = TransitionData.Direction.Right;
				break;

			case TransitionData.Direction.Right:
				_finalPosition = _transitionData.camRight;
				_transitionData.direction = TransitionData.Direction.Left;
				break;

			default:
				_finalPosition = _transitionData.camUp;
				_transitionData.direction = TransitionData.Direction.Down;
				Debug.Log("Neutral direction transition");
				break;
		}
	}

	void Update() {
		if (_doEntrance) {
			_timer += Time.deltaTime;
			float t = _timer / _transitionData.camTransitionTime;
			t = t > 1f ? 1f : t;
			float smoothStop3 = 1 - (1 - t) * (1 - t) * (1 - t);

			transform.position = Vector3.Lerp(_initPosition, _transitionData.camDefault, smoothStop3);
			if (_timer > _transitionData.camTransitionTime) {
				_timer = 0;
				_doEntrance = false;
			}
		}

		if (_doTransition) {
			_timer += Time.deltaTime;
			float t = _timer / _transitionData.camTransitionTime;
			t = t > 1f ? 1f : t;
			float smoothStart3 = t * t * t;

			transform.position = Vector3.Lerp(_initPosition, _finalPosition, smoothStart3);
			if (_timer > _transitionData.camTransitionTime) {
				_timer = 0;
				_doTransition = false;
				_sceneHandler.LoadScene(_scene);
			}
		}
	}

	void OnApplicationQuit() {
		if (_transitionData) {
			_transitionData.direction = TransitionData.Direction.None;
		}
	}
}
