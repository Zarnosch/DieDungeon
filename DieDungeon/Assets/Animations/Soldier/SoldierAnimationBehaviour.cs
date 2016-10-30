using UnityEngine;
using System.Collections;

public class SoldierAnimationBehaviour : MonoBehaviour {

    private Animator soldierAnimations;
    private Rigidbody2D rb;

    void Awake()
    {
        soldierAnimations = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        soldierAnimations.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}
