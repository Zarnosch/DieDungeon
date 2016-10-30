using UnityEngine;
using System;

[Serializable]
public class PlayerData {

	// private
	private int maxHealth = 3; // FIXME
	private int health;

	private Vector2 spawnPos;
	private Vector2 pos;

	private TimeLayer activeOnTimeLayer;

	// public
	public int MaxHalth {
		get { return maxHealth; }
	}

	public int Health { 
		get { return health; } 
	}

	public Vector2 Pos { 
		get { return pos; }
	}

	public TimeLayer ActiveOnLayer {
		get { return activeOnTimeLayer; }
	}

	public PlayerData(Vector2 spawnPos, TimeLayer activeOnLayer) {
		this.health = this.maxHealth;

		this.spawnPos = spawnPos;
		this.pos = this.spawnPos;

		activeOnTimeLayer = activeOnLayer;
	}

    public void TakeHit(int damage)
    {
        Debug.Log("Taking one for the team" + health);
        if (damage > 0 && health > 0)
            health--;
    }
}
