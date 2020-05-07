using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {
	[SerializeField] GameObject _transition = null;
	[SerializeField] string _scene = null;

	void Start() {
		FindObjectOfType<PlayerMovement>().LockMovement();
		FindObjectOfType<SceneHandler>().LoadScene(_scene, _transition);
	}
}
