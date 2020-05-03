using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetEnd : MonoBehaviour {
	[SerializeField] TransitionData.Direction _direction = TransitionData.Direction.None;
	[SerializeField] string _scene = null;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerMovement>().LockMovement();
			FindObjectOfType<CameraTransition>().DoTransition(_direction, _scene);
		}
	}
}
