using UnityEngine;

[CreateAssetMenu(fileName = "Transition_data", menuName = "ScriptableObjects/Transition Data")]
public class TransitionData : ScriptableObject {
	public GameObject transition;
	public Vector3 camDefault;
	public Vector3 camUp;
	public Vector3 camDown;
	public Vector3 camRight;
	public Vector3 camLeft;
	public Direction direction = Direction.None;
	[Min(0.001f)] public float camTransitionTime = 0;

	public enum Direction {
		None, Up, Down, Right, Left
	}
}