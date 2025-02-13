using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMonster : Monster
{
    protected override void Start()
    {
        Type = MonsterType.Mud;
        Speed = 600;
        Health = 100;
        Size = 5f;
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

    public float GetHealth()
    {
        return Health;
    }

}


