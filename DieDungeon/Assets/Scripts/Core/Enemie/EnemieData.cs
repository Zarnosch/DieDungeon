using UnityEngine;
using System;

[Serializable]
public class EnemieData
{

    // insert enemieData here
    public int fullHp;
    public int life { get; private set; }

    public void Start()
    {
        life = fullHp;
    }


    public bool TakeDamage(int dmg, HealthBar bar)
    {
        life -= dmg;
        Update(bar);
        return life >= 0;
    }

    public void Update(HealthBar bar)
    {
        bar.SetPercent((float)life / (float)fullHp);
    }
}
