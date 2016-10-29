using UnityEngine;
using System.Collections;

public class PlayerMovementBehaviour : MonoBehaviour {

	// public
	public float maxVelocity = 0.2f;

	public float accelerationSpeed = 0.4f;
	public float decelerationSpeed = 1.0f;

	public float percentWhennInAir = 0.85f;

	// private
	private float minVelocity = 0.0f;
	private float velocity = 0.0f;

	private PlayerJumpBehaviour pj;
	private Rigidbody2D rb;
	private ActiveInTimeLayerBehaviour ait;

	void Awake() {
		pj = GetComponent<PlayerJumpBehaviour>();
		rb = GetComponent<Rigidbody2D>();
		ait = GetComponent<ActiveInTimeLayerBehaviour>();
	}

	void Update() {
		if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ait.ActiveInTimeLayer) { return; }

		float input = Input.GetAxisRaw("Horizontal");

		if (input != 0) {
			velocity += accelerationSpeed * Time.deltaTime;
		} else {
			velocity -= decelerationSpeed * Time.deltaTime;	
		}
		velocity = pj.Grounded ? velocity : velocity * percentWhennInAir;

		velocity = Mathf.Clamp(velocity, minVelocity, maxVelocity);

		rb.velocity = new Vector2(velocity * input, rb.velocity.y);

	}
}
