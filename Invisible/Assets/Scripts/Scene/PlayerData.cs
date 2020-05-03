using UnityEngine;

[CreateAssetMenu(fileName = "Player_data", menuName = "ScriptableObjects/Player Data")]
public class PlayerData : ScriptableObject {
	[Min(0)] public float speed = 0;
	public Vector3 spawnDefault;
	public Vector3 spawnUp;
	public Vector3 spawnDown;
	public Vector3 spawnRight;
	public Vector3 spawnLeft;
	[Min(0)] public float spawnWalkTime = 0;

	public enum Direction {
		None, Up, Down, Right, Left
	}
}