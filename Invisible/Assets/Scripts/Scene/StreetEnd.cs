using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetEnd : MonoBehaviour {
	[SerializeField] TransitionData.Direction _direction = TransitionData.Direction.None;
	[SerializeField] PlayerData.Direction _moveDirection = PlayerData.Direction.None;
	[SerializeField] string _scene = null;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (_moveDirection != PlayerData.Direction.None) {
				other.GetComponent<PlayerMovement>().Move(_moveDirection, 30);
			}
			else {
				other.GetComponent<PlayerMovement>().LockMovement();
			}
			FindObjectOfType<CameraTransition>().DoTransition(_direction, _scene);
		}
	}
}
