using UnityEngine;
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

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {

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
