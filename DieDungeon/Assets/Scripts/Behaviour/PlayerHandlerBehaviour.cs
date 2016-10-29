using UnityEngine;
using System.Collections.Generic;

public class PlayerHandlerBehaviour : SingletonBehaviour<PlayerHandlerBehaviour> {

	// public
	public PlayerBehaviour playerPrefab;

	public PlayerBehaviour activePlayer;

	// private
	private List<PlayerBehaviour> players;

	override public void AwakeSingleton() {
		players = new List<PlayerBehaviour>();

		PlayerHandlerBehaviour.Instance.CreatePlayer();
	}

	public void CreatePlayer() {
		PlayerBehaviour player = GameObject.Instantiate(playerPrefab) as PlayerBehaviour;
		player.transform.parent = transform;
		player.GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer = IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer;
		players.Add(player);

		// set newly created player as active player
		activePlayer = player;
	}
		
	public void DestroyPlayer() {
		players.RemoveAt(players.Count - 1);

		activePlayer = players[players.Count - 1];
	}

}
