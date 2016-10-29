using UnityEngine;
using System.Collections;


public class EnemieBehaviour : MonoBehaviour
{
    public EnemieData Data;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<RangedWeaponBehaviour>() != null && coll.gameObject.GetComponent<OwnedByBehaviour>().Owner != Owner.Enemie)
        {
            if (!Data.TakeDamage(coll.gameObject.GetComponent<RangedWeaponBehaviour>().Data.Damage))
                KillMySelf();
        }
    }

    public void KillMySelf()
    {
        Destroy(gameObject);
    }
}
