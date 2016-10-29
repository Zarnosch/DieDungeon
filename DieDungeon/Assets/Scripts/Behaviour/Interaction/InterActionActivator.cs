using UnityEngine;
using System.Collections;

public class InterActionActivator : MonoBehaviour {

    public GameObject DestinationObstacle;
    public float Delay;
    private bool _triggered;
    private bool _inRange;


    void Awake()
    {
        _triggered = false;
    }

    void Update()
    {
        if (_inRange && Input.GetButtonDown("Fire3") && !_triggered)
        {
            _triggered = true;
            DestinationObstacle.GetComponent<MoveObstacleInteraction>().Activate(Delay, gameObject.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        _inRange = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _inRange = false;
    }
}
