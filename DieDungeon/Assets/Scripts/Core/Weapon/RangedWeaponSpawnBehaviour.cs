using UnityEngine;
using System.Collections;

public class RangedWeaponSpawnBehaviour : MonoBehaviour {

    public GameObject WeaponObject;
    public Vector3 InitShootVector;
    public float WeaponSpeed;
    public float FireRate;
    public bool AutoFire;
    public bool PlayerShoot;
    private float _fireCounter;

	// Use this for initialization
	void Start ()
    {
        _fireCounter = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _fireCounter += Time.deltaTime;
        if(_fireCounter >= FireRate)
        {
            _fireCounter = FireRate;
        }
        if (AutoFire && _fireCounter >= FireRate)
        {
            Shoot(new Vector3(0, 1, 0));
        }
        else if (Input.GetButtonDown("Fire2") && _fireCounter >= FireRate && PlayerShoot)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = transform.position.z;
            Vector3 shootdirection = mousepos - transform.position;
            Shoot(shootdirection);
        }
	}

    public void Shoot(Vector3 direc)
    {
        _fireCounter = 0f;
        GameObject temp = Instantiate(WeaponObject, gameObject.transform.position, Quaternion.identity) as GameObject;
        RangedWeaponBehaviour weaponBehaviour = temp.GetComponent<RangedWeaponBehaviour>();
        weaponBehaviour.MovementDirection = direc;
        weaponBehaviour.MovementSpeed = WeaponSpeed;

    }



}
