using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	// private
	private PlayerData player;

	// public
	public Vector2 spawnPos = new Vector2(0, 0);

	public PlayerData Player {
		get { return player; }
		set { }
	}

	void Awake() {
		player = new PlayerData(spawnPos);
	}

}
