using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMonster : Monster
{
    protected override void Start()
    {
        Type = MonsterType.Stone;
        Speed = 200;
        Health = 300;
        Size = 1f;
        AttackPower = 1;
        base.Start();
    }

    public void TakeDamage(float damage)
    {
        Health -= (int)damage;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return Health;
    }

}
