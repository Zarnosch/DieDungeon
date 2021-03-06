﻿using UnityEngine;
using System.Collections;

public class InterActionActivator : MonoBehaviour {

    public TimeLayer ActiveTimeLayer { get; private set; }
    public SpriteRenderer Renderer { get; private set; }
    public GameObject DestinationObstacle;
    public float Delay;
    private bool _triggered;
    private bool _inRange;

	private Animator anim;


    void Awake()
    {
        Renderer = GetComponentInChildren<SpriteRenderer>();
        ActiveTimeLayer = GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer;
        _triggered = false;

		anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Renderer.gameObject.layer = 0;
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveTimeLayer && ActiveTimeLayer != TimeLayer.All) return;
        Renderer.gameObject.layer = 8;
        if (_inRange && Input.GetButtonDown("Fire3") && !_triggered && IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != TimeLayer.First)
        {
            _triggered = true;
            DestinationObstacle.GetComponent<MoveObstacleInteraction>().Activate(Delay, gameObject.transform.position);
			anim.SetTrigger("Activate");
			IngameHandlerBehaviour.Instance.Handler.PopInceptState();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveTimeLayer && ActiveTimeLayer != TimeLayer.All) return;
        if (collider.tag == "Player")
        {
            _inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveTimeLayer && ActiveTimeLayer != TimeLayer.All) return;
        if (collider.tag == "Player")
        {
            _inRange = false;
        }
    }
}
