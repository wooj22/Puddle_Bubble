using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("WeaponType")]
    [SerializeField] public Player.WeaponType weaponType;

    [Header("Weapon Stats")]
    public float damage;             // 기본 데미지(총알에 붙일거임)
    public int ammoPerShot;          // 탄약 소모량
    public int remainAmmo;           // 잔여 탄약 수
    public int maxAmmo;              // 최대 탄약 수
    public float attackCoolTime;     // 발사 주기

    [Header("Assets")]
    public GameObject bulletPrefab;      // 총알 프리팹
    public Camera mainCamera;
    public Transform playerTrans;        // 총알 생성 위치
    //public AudioClip fireSFX;          // 발사 사운드

    private Vector2 mousPos;             // 마우스 위치
    private float lastAttackTime = 0f;   // 마지막 공격 시간

    // 공격
    public virtual void Attack()
    {
        // 쿨타임 제어
        if (Time.time - lastAttackTime < attackCoolTime)
            return;

        // 탄약체크 후 총알 생성
        if (remainAmmo >= ammoPerShot)
        {
            remainAmmo -= ammoPerShot;

            GameObject bullet = Instantiate(bulletPrefab, playerTrans.position, playerTrans.rotation);
            mousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            bullet.transform.LookAt(mousPos);

            lastAttackTime = Time.time;
        }
    }

    // 장전
    public void Loading()
    {
        
    }

    // 탄창버림
    public void InitAmmo()
    {
        remainAmmo = 0;
    }
}
