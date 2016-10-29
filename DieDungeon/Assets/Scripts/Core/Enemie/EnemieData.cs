using UnityEngine;
using System;

[Serializable]
public class EnemieData
{

    // insert enemieData here
    public int life { get; private set; }

    public void TakeDamage(int dmg)
    {
        life -= dmg;
        if(life <= 0)
        {
            Debug.Log("I am fucking dying you Sonofabtich");
        }
    }

}
