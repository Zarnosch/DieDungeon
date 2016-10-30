using UnityEngine;
using System.Collections;

public class FlyingMovementBehavior : MonoBehaviour {

    public float maxVelocity = 0.02f;

    public float accelerationSpeed = 0.015f;
    public float decelerationSpeed = 1.0f;

    private float minVelocity = 0.0f;
    private float velocityX = 0.0f;
    private float velocityY = 0.0f;

    PlayerBehaviour target;
    private bool allowMovement = true;

    public TimeLayer ActiveTimeLayer { get; private set; }

    private Rigidbody2D rb;
    private float flightHelper;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        target = PlayerHandlerBehaviour.Instance.activePlayer;
        flightHelper = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer != IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer && GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer != TimeLayer.All) return;

        float moveX = target.transform.position.x - gameObject.transform.position.x;

        if (moveX != 0)
        {
            velocityX += accelerationSpeed * Time.deltaTime;
        }
        else
        {
            velocityX -= decelerationSpeed * Time.deltaTime;
        }
        velocityX = Mathf.Clamp(velocityX, minVelocity, maxVelocity);

        float moveY = target.transform.position.y + 5f - gameObject.transform.position.y;
        if (Mathf.Abs(moveY) > 2)
        {
            velocityY += decelerationSpeed * Time.deltaTime;
        }
        else
        {
            velocityY -= decelerationSpeed * Time.deltaTime;
        }
        velocityY = Mathf.Clamp(velocityY, minVelocity, maxVelocity);

        flightHelper += .005f + Mathf.Abs(Random.value) * 0.05f;
        
        if (allowMovement)
            rb.velocity = new Vector2(velocityX * moveX, Mathf.Sin(flightHelper)*Time.deltaTime * 100f + (velocityY * moveY * 0.5f));
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
