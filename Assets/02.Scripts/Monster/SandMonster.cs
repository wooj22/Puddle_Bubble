using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMonster : Monster
{
    protected override void Start()
    {
        Type = MonsterType.Sand;
        Speed = 300;
        Health = 500;
        Size = 1f;
        AttackPower = 1;
        base.Start();
    }

    public void TakeDamage(float damage)
    {
        Health -= (int)damage;
        Debug.Log(Health);

        if( Health <=0 )
        {
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return Health;
    }
}