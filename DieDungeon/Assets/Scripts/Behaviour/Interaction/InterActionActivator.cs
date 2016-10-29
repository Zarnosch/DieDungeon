using UnityEngine;
using System.Collections;

public class InterActionActivator : MonoBehaviour {

    public GameObject DestinationObstacle;
    private bool _triggered;


    void Awake()
    {
        _triggered = false;
    }

    void OnTrigger2D(Collider2D collider)
    {
        if (Input.GetButtonDown("Fire3") && !_triggered)
        {
            DestinationObstacle.GetComponent<MoveObstacleInteraction>().Activate();
        }
    }


}
