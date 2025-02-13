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

}

