using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

	private Animator playerAnimations;
	private Rigidbody2D rb;

	void Awake() {
		playerAnimations = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		playerAnimations.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		playerAnimations.SetFloat("FallingSpeed", -rb.velocity.y);
	}
}
