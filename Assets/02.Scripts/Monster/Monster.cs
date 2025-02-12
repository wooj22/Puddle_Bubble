using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType { Sand, Mud } // 몬스터 종류
public enum MonsterGrade { Normal, Speed, Defense, Elite } // 몬스터 등급

public class Monster : MonoBehaviour
{
    public MonsterType Type;      // 몬스터 종류
    public MonsterGrade Grade;    // 몬스터 등급
    public float Speed;           // 이동 속도
    public int Health;            // 체력
    public float Size;            // 크기
    public int AttackPower;       // 공격력
    public Sprite[] GradeSprite;  // 등급별 스프라이트 배열

    protected SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        UpdateSprite(Grade);
        transform.localScale = new Vector3(Size, Size, 1f); // 크기 반영
    }

    public void UpdateSprite(MonsterGrade grade)
    {
        int gradeIndex = (int)grade;
        if (GradeSprite != null && gradeIndex >= 0 && gradeIndex < GradeSprite.Length)
        {
            spriteRenderer.sprite = GradeSprite[gradeIndex];
        }
        else
        {
            Debug.LogWarning($"Invalid grade index {gradeIndex} for {gameObject.name}");
        }
    }
}