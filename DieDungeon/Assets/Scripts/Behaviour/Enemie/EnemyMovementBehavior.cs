using UnityEngine;
using System.Collections;

public class EnemyMovementBehavior : MonoBehaviour {

    public float maxVelocity = 0.02f;

    public float accelerationSpeed = 0.015f;
    public float decelerationSpeed = 1.0f;

    private float minVelocity = 0.0f;
    private float velocity = 0.0f;

    public PlayerBehaviour target;
    private bool allowMovement = true;

    public TimeLayer ActiveTimeLayer { get; private set; }

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        target = PlayerHandlerBehaviour.Instance.activePlayer;
    }
	
	// Update is called once per frame
	void Update () {
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveTimeLayer && ActiveTimeLayer != TimeLayer.All) return;

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
            rb.velocity = new Vector2(velocity * move, rb.velocity.y);
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
