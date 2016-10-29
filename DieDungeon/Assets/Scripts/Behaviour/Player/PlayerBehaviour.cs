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

	private ActiveInTimeLayerBehaviour activeLayer;

	void Awake() {
		spawnPos = transform.position;
		playerData = new PlayerData(spawnPos, TimeLayer.First);

		activeLayer = GetComponent<ActiveInTimeLayerBehaviour>();
	}

	void Update() {
		if (activeLayer.ActiveInTimeLayer == IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer) {
			Debug.Log("8");
			gameObject.layer = 8;
		} else {
			Debug.Log("1");
			gameObject.layer = 0;
		}
	}

}
