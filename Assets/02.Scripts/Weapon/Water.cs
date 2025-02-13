using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Weapon
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("¹°ÃÑ Æ½");
    }
}
