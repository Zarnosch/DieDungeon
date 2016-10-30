using UnityEngine;
using System.Collections;


public class EnemieBehaviour : MonoBehaviour
{
    public EnemieData Data;
    private HealthBar bar;

	private SpriteRenderer sprite;
	private Rigidbody2D rb;
	private RangedWeaponSpawnBehaviour rwsb;

    public void Awake()
    {
        bar = gameObject.GetComponentInChildren<HealthBar>();
        Data.Start();
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		rwsb = GetComponent<RangedWeaponSpawnBehaviour>();
    }

    public void Start()
    {
        Data.Update(bar);
    }

	void Update() {
		if (rb.velocity.x > 0) {
			sprite.flipX = false;
		} else {
			sprite.flipX = true;
		}
	}

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<RangedWeaponBehaviour>() != null && coll.gameObject.GetComponent<OwnedByBehaviour>().Owner != Owner.Enemie)
        {
			if (rwsb.IsBad) {
				if (!Data.TakeDamage(coll.gameObject.GetComponent<RangedWeaponBehaviour>().Data.Damage, bar)) {
					KillMySelf();	
				}
			}

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
