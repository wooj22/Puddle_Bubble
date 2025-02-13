using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMonster : Monster
{
    public Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();

        Type = MonsterType.Mud;
        Speed = 600;
        Health = 100;
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
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.5f);
        }
    }

    public int GetHealth()
    {
        return Health;
    }

}


