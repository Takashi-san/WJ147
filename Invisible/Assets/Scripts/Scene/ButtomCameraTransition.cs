using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomCameraTransition : MonoBehaviour {
	[SerializeField] TransitionData.Direction _direction = TransitionData.Direction.None;

	public void DoTransition(string scene) {
		FindObjectOfType<CameraTransition>().DoTransition(_direction, scene);
	}
}
