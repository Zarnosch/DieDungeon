using UnityEngine;
using System.Collections;

public class MoveObstacleInteraction : MonoBehaviour {

    public Rigidbody2D RigidbodyOfThisObstacle;
    public Vector2 ForceOnActivate;
    private bool _triggered;

	// Use this for initialization

    void Awake()
    {
        _triggered = false;
        RigidbodyOfThisObstacle = GetComponent<Rigidbody2D>();
        RigidbodyOfThisObstacle.constraints = RigidbodyConstraints2D.FreezeAll;
    }


    void OnTrigger2D(Collider2D collider)
    {
        if (Input.GetButtonDown("Fire3") && !_triggered)
        {
            Activate();
        }
    }

    public void Activate()
    {
        _triggered = true;
        RigidbodyOfThisObstacle.constraints = RigidbodyConstraints2D.None;
        RigidbodyOfThisObstacle.AddForce(ForceOnActivate);
    }
}
