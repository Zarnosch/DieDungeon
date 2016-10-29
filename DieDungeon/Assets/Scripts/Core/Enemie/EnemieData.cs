using UnityEngine;
using System;

[Serializable]
public class EnemieData
{

    // insert enemieData here
    public int FullHp;
    public int life { get; private set; }

    public void Start()
    {
        life = FullHp;
    }

    public bool TakeDamage(int dmg)
    {
        life -= dmg;
        if(life <= 0)
        {
            Debug.Log("I am fucking dying you Sonofabtich");
        }
        return life >= 0;
    }

}
