using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	// private
	private Vector2 spawnPos = new Vector2(0, 0);
	private PlayerData player;

	public PlayerData Player {
		get { return player; }
	}

	void Awake() {
		spawnPos = transform.position;
		player = new PlayerData(spawnPos);
	}

}
