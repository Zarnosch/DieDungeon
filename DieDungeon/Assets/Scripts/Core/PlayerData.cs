using UnityEngine;
using System;

[Serializable]
public class PlayerData {

	// private
	private int maxHealth = 3; // FIXME
	private int health;

	private Vector2 spawnPos;
	private Vector2 pos;

	// public
	public int MaxHalth {
		get { return maxHealth; }
		set { }
	}

	public int Health { 
		get { return health; } 
		set { }
	}

	public Vector2 Pos { 
		get { return pos; }
		set { } 
	}

	public PlayerData(Vector2 spawnPos) {
		this.health = this.maxHealth;

		this.spawnPos = spawnPos;
		this.pos = this.spawnPos;
	}
}
