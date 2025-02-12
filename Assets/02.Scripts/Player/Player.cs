using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] public int currentHealth;
    [SerializeField] private float maxHealth = 100f;

    [Header("State")]
    public PlayerState currentPlayerState;  // 플레이어 속도 제어 상태
    public WeaponType mainWeaponType;       // 현재 메인탄창
    public WeaponType subWeaponType;        // 현재 서브 탄창

    public enum PlayerState { Idle, Move, Shoot }
    public enum WeaponType { Bomb, Water, Getling }
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
}
