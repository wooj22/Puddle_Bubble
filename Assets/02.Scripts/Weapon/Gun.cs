using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float damage;             // 기본 데미지
    public int ammoPerShot;          // 탄약 소모량
    public int remainAmmo;           // 잔여 탄약 수
    public float attackCoolTime;     // 발사 주기

    [Header("Assets")]
    public GameObject bulletPrefab;      // 총알 프리팹
    public Transform muzzlePoint;        // 총알 생성 위치
    public ParticleSystem muzzleFlash; // 총구 화염 이펙트
    public AudioClip fireSFX;          // 발사 사운드

    private float lastAttackTime = 0f;   // 마지막 공격 시간

    // 공격
    public void Attack()
    {
        // 쿨타임 제어
        if (Time.time - lastAttackTime < attackCoolTime)
            return;

        // 탄약 확인
        if (remainAmmo >= ammoPerShot)
        {
            Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            remainAmmo -= ammoPerShot;
            lastAttackTime = Time.time;
        }
    }
}
