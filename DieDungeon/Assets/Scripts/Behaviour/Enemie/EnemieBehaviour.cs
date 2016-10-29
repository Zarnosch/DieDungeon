using UnityEngine;
using System.Collections;


public class EnemieBehaviour : MonoBehaviour
{
    EnemieData Data;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "RangedWeapon")
        {
            Data.TakeDamage(coll.gameObject.GetComponent<RangedWeaponBehaviour>().Data.Damage);
        }
    }

}
