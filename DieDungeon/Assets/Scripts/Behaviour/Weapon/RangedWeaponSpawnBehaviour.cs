﻿using UnityEngine;
using System.Collections;

public class RangedWeaponSpawnBehaviour : MonoBehaviour {

    public bool IsBad;
    private Animator anim;
    public GameObject WeaponObject;
    public Vector3 InitShootVector;
    public float WeaponSpeed;
    public float FireRate;
    public bool AutoFire;
    public Owner Owner;

	public float ShootRange = 7.0f;

    private float _fireCounter;
    public float startPosX;
    public float startPosY;
    public TimeLayer ActiveInTimeLayer { get; private set; }

	private SpriteRenderer sprite;

    void Awake()
    {
        ActiveInTimeLayer = GetComponent<ActiveInTimeLayerBehaviour>().ActiveInTimeLayer;
        anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
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
			if ((PlayerHandlerBehaviour.Instance.activePlayer.transform.position - transform.position).magnitude < ShootRange) {
				Shoot(PlayerHandlerBehaviour.Instance.activePlayer.transform.position - transform.position, Owner.Enemie);
			}
            	
        }
        else if (Input.GetButtonDown("Fire2") && _fireCounter >= FireRate && Owner == Owner.Player)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = transform.position.z;
            Vector3 shootdirection = mousepos - transform.position;
            Shoot(shootdirection, Owner);
        }
	}

	public void Shoot(Vector3 direc, Owner owner, bool left = false)
    {

        if (!IsBad)
        {
            anim.SetTrigger("Attack");
        }
        _fireCounter = 0f;
		GameObject temp;
		if (sprite && sprite.flipX) {
			temp = Instantiate(WeaponObject, gameObject.transform.position + new Vector3(-startPosX, startPosY, 0), Quaternion.identity) as GameObject;	
		} else {
			temp = Instantiate(WeaponObject, gameObject.transform.position + new Vector3(startPosX, startPosY, 0), Quaternion.identity) as GameObject;
		}
        
        RangedWeaponBehaviour weaponBehaviour = temp.GetComponent<RangedWeaponBehaviour>();
        weaponBehaviour.GetComponent<OwnedByBehaviour>().Owner = owner;
        weaponBehaviour.ActiveInTimeLayer = ActiveInTimeLayer;
        weaponBehaviour.MovementDirection = direc;
        weaponBehaviour.MovementSpeed = WeaponSpeed;

    }



}
