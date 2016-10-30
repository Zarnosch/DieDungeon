using UnityEngine;
using System.Collections;

public class RangedWeaponSpawnBehaviour : MonoBehaviour {

    private Animator anim;
    public GameObject WeaponObject;
    public Vector3 InitShootVector;
    public float WeaponSpeed;
    public float FireRate;
    public bool AutoFire;
    public Owner Owner;
    private float _fireCounter;
    public float startPosX;
    public float startPosY;
    public TimeLayer ActiveInTimeLayer { get; private set; }

    void Awake()
    {
        ActiveInTimeLayer = GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer;
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start ()
    {
        _fireCounter = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IngameHandlerBehaviour.Instance.Handler.ActiveTimeLayer != ActiveInTimeLayer && ActiveInTimeLayer != TimeLayer.All) { return; }
        _fireCounter += Time.deltaTime;
        if(_fireCounter >= FireRate)
        {
            _fireCounter = FireRate;
        }
        if (AutoFire && _fireCounter >= FireRate && Owner == Owner.Enemie)
        {
            Shoot(PlayerHandlerBehaviour.Instance.activePlayer.transform.position - transform.position, Owner.Enemie);
        }
        else if (Input.GetButtonDown("Fire2") && _fireCounter >= FireRate && Owner == Owner.Player)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = transform.position.z;
            Vector3 shootdirection = mousepos - transform.position;
            Shoot(shootdirection, Owner);
        }
	}

    public void Shoot(Vector3 direc, Owner owner)
    {
        anim.SetTrigger("Attack");
        _fireCounter = 0f;
        GameObject temp = Instantiate(WeaponObject, gameObject.transform.position + new Vector3(startPosX, startPosY, 0), Quaternion.identity) as GameObject;
        RangedWeaponBehaviour weaponBehaviour = temp.GetComponent<RangedWeaponBehaviour>();
        weaponBehaviour.GetComponent<OwnedByBehaviour>().Owner = owner;
        weaponBehaviour.ActiveInTimeLayer = ActiveInTimeLayer;
        weaponBehaviour.MovementDirection = direc;
        weaponBehaviour.MovementSpeed = WeaponSpeed;

    }



}
