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
	private Rigidbody2D rb;

	void Awake() {
		spawnPos = transform.position;
		playerData = new PlayerData(spawnPos, TimeLayer.First);

		activeLayer = GetComponent<ActiveInTimeLayerBehaviour>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
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
        Owner owner = coll.gameObject.GetComponent<OwnedByBehaviour>().Owner;
        if (weapon != null &&  owner != Owner.Player)
            PlayerData.TakeHit(weapon.Data.Damage);
    }
}
