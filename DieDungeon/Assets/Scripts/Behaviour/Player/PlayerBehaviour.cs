﻿using UnityEngine;
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
	private Rigidbody2D rb;
	private SpriteRenderer sr;

	void Awake() {
		spawnPos = transform.position;
		playerData = new PlayerData(spawnPos, TimeLayer.First);

		activeLayer = GetComponent<ActiveInTimeLayerBehaviour>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	void Update() {
		if (rb.velocity.x < 0) {
			sr.flipX = true;
		} else if (rb.velocity.x > 0){
			sr.flipX = false;
		}

		if (activeLayer.ActiveInTimeLayer == IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer) {
			gameObject.layer = 8; // Keep Colored
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		} else {
			gameObject.layer = 0; // Default
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}

    public void OnTriggerEnter2D(Collider2D coll)
    {

        RangedWeaponBehaviour weapon = coll.GetComponent<RangedWeaponBehaviour>();
        OwnedByBehaviour owner = coll.gameObject.GetComponent<OwnedByBehaviour>();
        if (owner != null && weapon != null && owner.Owner != Owner.Player)
        {
            TimeLayer collisionTimeLayer = coll.GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer;
            if (activeLayer.ActiveInTimeLayer == collisionTimeLayer || collisionTimeLayer == TimeLayer.All)
            {
                if (PlayerData.TakeHit(weapon.Data.Damage))
                    Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (coll.tag == "KillCollider")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
