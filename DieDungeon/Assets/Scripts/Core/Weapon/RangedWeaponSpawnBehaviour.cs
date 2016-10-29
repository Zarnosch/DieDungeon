using UnityEngine;
using System.Collections;

public class RangedWeaponSpawnBehaviour : MonoBehaviour {

    public GameObject WeaponObject;
    public Vector3 InitShootVector;
    public float WeaponSpeed;
    public float FireRate;
    public bool AutoFire;

	// Use this for initialization
	void Start ()
    {
        if (AutoFire)
        {
            StartCoroutine(Shoot());
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!AutoFire && Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
	}

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(WeaponSpeed);

        while (AutoFire)
        {
            GameObject temp = Instantiate(WeaponObject, transform) as GameObject;
            RangedWeaponBehaviour weaponBehaviour = temp.GetComponent<RangedWeaponBehaviour>();
            weaponBehaviour.MovementDirection = InitShootVector;
            weaponBehaviour.MovementSpeed = WeaponSpeed;
            yield return new WaitForSeconds(WeaponSpeed);            
        }
    }


}
