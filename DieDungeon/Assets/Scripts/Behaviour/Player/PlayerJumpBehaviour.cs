﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumpBehaviour : MonoBehaviour {

	// public
	public float jumpForce = 400.0f;

	public bool Grounded {
		get { return grounded; }
	}

	// private
	private bool grounded = false;

	private Rigidbody2D rb;
	private ActiveInTimeLayerBehaviour ait;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		ait = GetComponent<ActiveInTimeLayerBehaviour>();
	}

	void Update() {
		if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ait.ActiveInTimeLayer) { return; }

		if (grounded && Input.GetButtonDown("Jump")) {
			rb.AddForce(Vector2.up * jumpForce);
			grounded = false;
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Ground") {
			grounded = true;
		}
	}

}
