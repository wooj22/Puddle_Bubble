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
        Size = 5f;
        AttackPower = 1;
        base.Start();
    }

}

