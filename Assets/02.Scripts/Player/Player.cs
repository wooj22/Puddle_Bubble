using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] public int hp = 100;

    [Header("State")]
    public PlayerState currentPlayerState;  // 플레이어 속도 제어 상태
    public WeaponType mainWeaponType;       // 현재 메인탄창
    public WeaponType subWeaponType;        // 현재 서브 탄창

    public enum PlayerState { Idle, Move, Shoot }
    public enum WeaponType { Bomb, Water, Getling }
    public bool isLoading { get; set; }
    public bool isDie { get; set; }

    // 싱글톤
    public static Player Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 피격
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            isDie = true;
            return;
        }
    }

    // 플레이어 죽음 루틴
    public void Die()
    {

    }
}
