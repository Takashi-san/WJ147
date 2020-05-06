using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnDisableCallback : MonoBehaviour {
	Action _callback;

	public void Setup(Action callback) {
		_callback = callback;
	}

	void OnDisable() {
		if (_callback != null) {
			_callback();
		}
	}
}
