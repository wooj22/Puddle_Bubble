using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ★ 몬스터 데이터를 저장하는 ScriptableObject ★


[CreateAssetMenu(fileName = "NewMonsterData", menuName = "Game/Monster Data")]
public class MonsterDataSO : ScriptableObject
{
    public string Type;       // 몬스터 이름 (Sand, Mud)
    public float Speed;       // 이동 속도
    public int Health;        // 체력
    public float Size;        // 크기
    public int AttackPower;   // 공격력
    public Sprite Sprite;     // 몬스터의 스프라이트
}
