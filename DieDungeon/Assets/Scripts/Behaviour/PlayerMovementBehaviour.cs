using UnityEngine;
using System.Collections;

public class PlayerMovementBehaviour : MonoBehaviour {

	// public
	public float maxVelocity = 0.2f;

	public float accelerationSpeed = 0.4f;
	public float decelerationSpeed = 1.0f;

	// private
	private float minVelocity = 0.0f;
	private float velocity = 0.0f;

	void Update () {

		float input = Input.GetAxis("Horizontal");

		if (input != 0) {
			velocity += accelerationSpeed * Time.deltaTime;
		} else {
			velocity -= decelerationSpeed * Time.deltaTime;	
		}
		velocity = Mathf.Clamp(velocity, minVelocity, maxVelocity);

		transform.Translate(velocity * input, 0, 0);
	}
}
