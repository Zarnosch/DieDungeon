using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInceptBehaviour))]
[RequireComponent(typeof(PlayerMovementBehaviour))]
[RequireComponent(typeof(PlayerJumpBehaviour))]
[RequireComponent(typeof(ActiveInTimeLayerBehaviour))]
public class PlayerBehaviour : MonoBehaviour {

	// public
	public PlayerData PlayerData {
		get { return playerData; }
	}

	// private
	private Vector2 spawnPos = new Vector2(0, 0);
	private PlayerData playerData;

	void Awake() {
		spawnPos = transform.position;
		playerData = new PlayerData(spawnPos, TimeLayer.First);
	}

}
