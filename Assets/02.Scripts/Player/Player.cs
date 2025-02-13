using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField] public int hp = 5;
    [SerializeField] public int invincibilityTime = 2;  // 무적타임

    [Header("State")]
    public PlayerState currentPlayerState;  // 플레이어 속도 제어 상태
    public WeaponType mainWeaponType;       // 현재 메인탄창
    public WeaponType subWeaponType;        // 현재 서브 탄창

    public enum PlayerState { Idle, Move, Shoot }
    public enum WeaponType { Bomb, Water, Getling }
    public bool isLoading { get; set; }
    public bool isDie { get; set; }
    private bool isDamageing;

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
    public void TakeDamage()
    {
        if (isDamageing) return; // 무적 상태

        isDamageing = true;
        hp--;
        PlayerUIManager.Instance.HpUiIconDown();    // 아이콘 UI
        SoundManager.Instance.PlaySFX("SFX_PlayerDamaged");

        if (hp <= 0)
        {
            hp = 0;
            isDie = true;
            Die();
            return;
        }

        StartCoroutine(InvincibilityCoroutine());
    }

    private IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isDamageing = false;
    }

    // Die
    public void Die()
    {

    }
}
