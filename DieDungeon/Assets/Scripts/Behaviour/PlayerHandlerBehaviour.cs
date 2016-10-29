using UnityEngine;
using System.Collections.Generic;

public class PlayerHandlerBehaviour : SingletonBehaviour<PlayerHandlerBehaviour> {

	// public
	public PlayerBehaviour playerPrefab;

	public Vector2 spawnPosition = new Vector2(0, 4);

	[HideInInspector]
	public PlayerBehaviour activePlayer;

	// private
	private Stack<PlayerBehaviour> players;

	override public void AwakeSingleton() {
		players = new Stack<PlayerBehaviour>();

		PlayerHandlerBehaviour.Instance.CreatePlayer();
	}

	public void CreatePlayer() {
		PlayerBehaviour player = GameObject.Instantiate(playerPrefab) as PlayerBehaviour;
		player.transform.parent = transform;
		player.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0);

		player.gameObject.SetActive(true);

		player.GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer = IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer;

		players.Push(player);

		// set newly created player as active player
		activePlayer = player;
	}
		
	public void DestroyPlayer() {
		PlayerBehaviour player = players.Pop();

		Destroy(player.gameObject);

		activePlayer = players.Peek();

	}

}
