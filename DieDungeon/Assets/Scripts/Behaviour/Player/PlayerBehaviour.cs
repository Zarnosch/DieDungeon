using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	// public
	public Vector2 spawnPos = new Vector2(0, 0);

	// private
	private PlayerData player;

	void Awake() {
		player = new PlayerData(spawnPos);
	}

}
