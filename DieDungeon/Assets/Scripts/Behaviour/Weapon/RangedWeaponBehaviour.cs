using UnityEngine;
using System.Collections;


public class RangedWeaponBehaviour : MonoBehaviour {

    public RangedWeaponData Data;
    public Vector3 MovementDirection;
    public float MovementSpeed;
    public GameObject Explosion;

    void Update()
    {
        transform.Translate(MovementDirection * MovementSpeed * Time.deltaTime);
    }
}
