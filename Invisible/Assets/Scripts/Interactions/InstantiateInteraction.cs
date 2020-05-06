using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Instantiate_interaction", menuName = "ScriptableObjects/Interactions/Instantiate Interaction")]
public class InstantiateInteraction : Interactions {
	[SerializeField] GameObject _Create = null;

	public override void Interaction(Action callback) {
		GameObject created = Instantiate(_Create);
		created.GetComponent<OnDisableCallback>().Setup(callback);
	}
}
