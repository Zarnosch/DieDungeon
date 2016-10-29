using UnityEngine;
using System.Collections;

public class EnemyMovementBehavior : MonoBehaviour {

    public float maxVelocity = 0.02f;

    public float accelerationSpeed = 0.015f;
    public float decelerationSpeed = 1.0f;

    private float minVelocity = 0.0f;
    private float velocity = 0.0f;

    public GameObject target;
    private bool allowMovement = true;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        float move = target.transform.position.x - gameObject.transform.position.x;

        if(move != 0)
        {
            velocity += accelerationSpeed * Time.deltaTime;
        }
        else
        {
            velocity -= decelerationSpeed * Time.deltaTime;
        }
        velocity = Mathf.Clamp(velocity, minVelocity, maxVelocity);

        if (allowMovement)
            transform.Translate(move * velocity, 0, 0);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            allowMovement = false;
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            allowMovement = true;
    }
}
