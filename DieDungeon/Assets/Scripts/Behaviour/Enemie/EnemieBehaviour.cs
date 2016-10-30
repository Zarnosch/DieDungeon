using UnityEngine;
using System.Collections;


public class EnemieBehaviour : MonoBehaviour
{
    public EnemieData Data;
    private HealthBar bar;

    public void Awake()
    {
        bar = gameObject.GetComponentInChildren<HealthBar>();
        Data.Start();
    }

    public void Start()
    {
        Data.Update(bar);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<RangedWeaponBehaviour>() != null && coll.gameObject.GetComponent<OwnedByBehaviour>().Owner != Owner.Enemie)
        {
            if (!Data.TakeDamage(coll.gameObject.GetComponent<RangedWeaponBehaviour>().Data.Damage, bar))
                KillMySelf();
        }
        if (coll.tag == "InteractionObstacle" && coll.GetComponent<Rigidbody2D>().velocity.y < -0.1 && (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer == TimeLayer.Second || IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer == TimeLayer.Third))
        {
            KillMySelf();
        }
    }

    public void KillMySelf()
    {
        Destroy(gameObject);
    }
}
